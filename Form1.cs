
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grains
{


    public partial class Form1 : Form
    {

        int actualLayerNumber = 0;
        int numberOfLayer = 0;
        int lastID = 0;
        int Coord = 0;
        public HashSet<Grain> nonUsedGrains = new HashSet<Grain>();
     //   public List<Grain> nonUsedGrains = new List<Grain>();
        private List<SolidBrush> brushes;
        public Bitmap bmp;
        public Graphics graph;
        Thread tr;
        Thread growthThread;
        bool isThreadAlive = false;
        bool isThreadStarted;
        private static object lockBrush;
        private  int layerHeight;
        private  int layerGerne;
        private  int widthSize;
        private  int heightSize;
        private  int lastValueHeight;
        private  int actuahHeightofLayer;
        private bool isRandomPosition;

        
        //F//unc<Algorithms, bool> isGrow = growing => growing.growthStep();

   

      //  bool value;
        int flaga = 0;
        public Grid gr;
        public  Form1()
        {
            lockBrush = new object();
            InitializeComponent();
            LoadCombobox();
         
            LayerGerne = int.Parse(tbLayerGerne.Text);
            WidthSize = int.Parse(TbWidth.Text);

            HeightSize = int.Parse(tbHeight.Text);
           
          //  tr = new Thread(new ThreadStart(DrawBitmap));
            // GrowthSthepCallback call = new GrowthSthepCallback
            SetupBrushes();
        
        }





        #region properties
        public int ActualHeightOfLayers
        {
            get { return actuahHeightofLayer; }
            set { actuahHeightofLayer = value; }
        }

        public int LayerHeight
        {
            get
            {
                return layerHeight;
            }
            set
            {
                layerHeight = value;
            }
        }

        public int LayerGerne
        {

            get
            {
                return layerGerne;
            }
            set
            {
                layerGerne = value;

            }
        }
        
        public int WidthSize
        {
            get
            {
                return widthSize;

            }
            set { widthSize = value; }
        }


        protected BoundaryConditions boundaryCondition;

        public BoundaryConditions BoundaryConditionSelected
        {
            get { return boundaryCondition; }
            set { boundaryCondition = value; }
        }


        public NeighbourType neighbourType;

        public NeighbourType NeighbourTypeSelected
        {
            get { return neighbourType; }
            set { neighbourType = value; }
        }

        public int ActualLayerNumber
        {
            get
            {
                return actualLayerNumber;
            }
            set
            {
                actualLayerNumber = value;
            }
        }


        //public bool PrevoiusLayerCA
        //{
        //    get
        //    {
        //        return chkPreviousNeighbourCA.Checked ? true : false;
        //    }
        //}
        /// <summary>
        /// blokada inicjuj 
        /// </summary>

        public int HighestIdLayerValue
        {
            get
            {
                return lastID;
            }

            set
            {
                lastID = value;
            }
        }
        public bool IsRandomPosition
        {
            get { return isRandomPosition; }
            set { isRandomPosition = value; }
        }

        public int HeightSize
        {
            get { return heightSize; }
            set { heightSize = value; }
        }

        private void LoadCombobox()
        {

            Sasiedztwo.DataSource = Enum.GetValues(typeof(NeighbourType));
            
        }
        #endregion


        private void MainThread()
        {
            while (isThreadAlive)
            {
                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                if (isThreadStarted)
                {


                    Array.Copy(gr.grid, gr.tempGrid, gr.grid.Length);
                    Algorithms Algorithm = new Algorithms(gr.grid, gr.tempGrid, ActualHeightOfLayers, NeighbourTypeSelected, BoundaryConditionSelected, ActualLayerNumber);
                    Algorithm.growthStep();
                    Draw(gr.grid, gr.tempGrid, ActualHeightOfLayers);
                    if (!isHeightReached(ActualHeightOfLayers))
                    {
                        isThreadAlive = false;
                        isThreadStarted = false; 
                    }
                }
      
            }
        }

       
        private bool isHeightReached(int height)
        {
            if(height ==HeightSize)
            {

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < WidthSize; j++)
                    {

                        if (gr.grid[i, j].isEmpty)
                           return true;
                    }
                }

                return false;
            }
            else
            {
               // if (ActualLayerNumber == 1)
               // {
                    for (int i = height - 1; i < height; i++)
                    {
                        for (int j = 0; j < WidthSize; j++)
                        {
                            //inicjuj w trakcie rysowania
                            if (!gr.grid[i, j].isEmpty)
                                return false;
                        }
                    }
                    return true;
               // }
                //else
                //{
                //    for (int i = height - 1; i < height; i++)
                //    {
                //        for (int j = 0; j < WidthSize; j++)
                //        {
                //            if (!gr.grid[i,j].isEmpty)
                //            {
                //                return Check(height);
                //            }
                //        }
                //    }
                //    return true;
                //}
            }
        }

        //private bool Check(int height)
        //{
        //    bool flaga = false;
           
        //        for (int j = 0; j < WidthSize; j++)
        //        {
        //        if (gr.grid[0, j].isEmpty)
        //            return true;
                       
                    
        //        }
        //    return false;
            
         
        //}







        #region buttonEvents
        private async void btnInit_Click(object sender, EventArgs e)
        {
            Init();
            btnInsert.Enabled = true;
            btnInit.Enabled = false;
           // brushes = await SetupBrushes();
            
        }







        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!tr.IsAlive)
            //{
            //    tr = new Thread(DrawBitmap);
            //    tr.IsBackground = true;
            //    tr.Start();
            //}


            SaveFileDialog SaveBMP = new SaveFileDialog();
            SaveBMP.Filter = "Images|*.bmp";
            ImageFormat format = ImageFormat.Bmp;
            if (SaveBMP.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(SaveBMP.FileName);
                paintArea.Image.Save(SaveBMP.FileName, ImageFormat.Bmp);
            }
          
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!isThreadNull())
            {
                growthThread.Abort();
                isThreadAlive = false;
                growthThread = new Thread(new ThreadStart(MainThread));
            }
            ClearValues();
            btnDraw.Enabled = false;
            btnStopDraw.Enabled = false;
            // Task b = Task.Factory.StartNew(() => ClearValues()).ContinueWith(prev => Init(),TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith(prev => Draw(), TaskScheduler.FromCurrentSynchronizationContext());
            //ClearValues();
            //Init();
            //Draw();
        }


        private void buttonDraw_Click(object sender, EventArgs e)
        {

            isThreadStarted = false;

            //LastValueHeight += LayerHeight;
            //chkPreviousNeighbourCA.Enabled = true;
            //flaga = 0;
        }

        private bool isThreadNull()
        {
            if (growthThread == null)
            {
                return true;
            }
            else
                return false;
        }

        private void paintArea_MouseClick(object sender, MouseEventArgs e)
        {

            HighestIdLayerValue++;
            if (!gr.grid[e.Y, e.X].isEmpty)
            {
                MessageBox.Show(getDescrpition(gr.grid[e.Y, e.X]));
            }
            else
            {
                if (!isHeightReached(ActualHeightOfLayers))
                {
                    MessageBox.Show("Nie mozna dodać do istniejącej warstwy zarodków ponieważ osięgnała ona maksymalną wysokość");
                }
                else
                    {
                    btnStopDraw.Enabled = true;
                    gr.grid[e.Y, e.X].ID = HighestIdLayerValue;
                    gr.grid[e.Y, e.X].numberOfLayer = ActualLayerNumber;

                    flaga++;

                   // using (Graphics g = Graphics.FromImage(bmp))
                    {

                        lock (lockBrush)
                        {
                            try
                            {
                                bmp.SetPixel( e.X, e.Y, brushes[HighestIdLayerValue].Color);
                            }
                            catch (Exception)
                            {

                                graph.Dispose();
                            }
                        }
                       
                    }


                    HighestIdLayerValue++;
                }
            }




        }


        private async void buttonInsert_Click(object sender, EventArgs e)
        {
            if (!GetValues()) return;


            //  var t1 = Task.Factory.StartNew( () => await FillListOfUnusedGrains()).ContinueWith((prevTask) =>  InsertGerne(nonUsedGrains)).ContinueWith((prevTask)=>DrawLayer(ActualHeightOfLayers));
            //  t1.Wait();

            //  var t1 = Task.Factory.StartNew(async () => await Task.Run(FillListAsync)).ContinueWith(async (prewTask) => await Task.Run(() => InsertGerneAsync(nonUsedGrains))).ContinueWith(async (prewTask) => await Task.Run(()=>DrawLayerAsync(ActualHeightOfLayers)));
            //await 

            btnDraw.Enabled = false;
            await Task.Run(FillListAsync);
            await Task.Run(()=>InsertGerneAsync(nonUsedGrains));
            await Task.Run(()=>DrawLayerAsync(ActualHeightOfLayers));

            //Task.WaitAll();
       
        
           btnDraw.Enabled = true;
            //   Task t1 = new Task(()=>DrawLayer(actuahHeightofLayer) );
            //  t1.ContinueWith((prev) => TaskScheduler.FromCurrentSynchronizationContext());
            //  t1.Start();
            //DrawLayer(actuahHeightofLayer);
             btnStopDraw.Enabled = true;
        }
        #endregion

        async Task FillListAsync()
        {
            //lblResult.Text = "Tworzenie zarodków.... ";
            //btnStopDraw.Enabled = false;
            if (isRandomPosition)
            {
                if (ActualLayerNumber == 0)
                {
                   await  FillOnStartAsync();

                }
                else
                {
                  await  FillListAsync(ActualHeightOfLayers);

                }

            }
            else
            {
                if (ActualLayerNumber == 0)
                {
                 await   FillOnStartAsync(isRandomPosition);

                }
                else
                {
                  await FillListAsync(ActualHeightOfLayers, IsRandomPosition);

                }

            }

        }
   

        #region methods 
        // <summary>
        /// metoda rysujaca warstwe do odpowieniej wysokosci zadanej w parametrze height
        /// </summary>
        /// <param name="height"></param>
        
        private async Task DrawLayerAsync(int height)
        {

             // lblResult.Text = "Rysowanie Tabeli....";
           // btnDraw.Enabled = false;
      var watch1 = System.Diagnostics.Stopwatch.StartNew();

        Parallel.For(0, height, i =>
            {
                for (int j = 0; j < WidthSize; j++)
                {
                    lock (lockBrush)
                    {

                    //  gr.grid[i, j].nrWarstwy = ActualLayerNumber;

                      //  using (Graphics graph = Graphics.FromImage(bmp))
                        {
                            try
                            {
                                if (gr.grid[i, j].ID != 0)
                                {
                                    bmp.SetPixel(j, i, brushes[gr.grid[i, j].ID].Color);
                                    //graph.FillRectangle(brushes[gr.grid[i, j].ID], j, i, 1, 1);
                                }
                            }
                            catch (Exception)
                            {

                                graph.Dispose();
                            }
                           
                        }

                    

                            
                    }
                 
                }


            });

            paintArea.Invalidate();
            var elapsedMs = watch1.ElapsedMilliseconds;

            Console.WriteLine("Draw Layer Parallel: " + elapsedMs.ToString());
           // btnDraw.Enabled = true;
           
        }

        //}


        /// <summary>
        /// metoda wypisująca szczegóły danego ziarna 
        /// </summary>

        private string getDescrpition(Grain gr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ziarno o id : " + gr.ID + " numer warstwy " + gr.numberOfLayer);
            return sb.ToString();
        }
      

        /// <summary>
        /// metoda sprawdzajaca czy checkbox 'losowo' jest zaznaczony. jesli tak , stosuj losowosc , jesli nie to rownomiernosc
        /// </summary>
        /// <returns>rdo</returns>
        private bool IsRandom()
        {
            return rdoRandom.Checked;
        }




        private bool GetValues()
        {
            int layerHeightpom;
            int.TryParse(tbLayerHeight.Text, out layerHeightpom);
            int pom = ActualHeightOfLayers + layerHeightpom;
            if (pom > HeightSize)
            {
                MessageBox.Show("Wartość przekracza maksimum tablicy , które wynosi " + HeightSize + ". Ostatnia wysokość warstwy  może przyjąć wartosc " + (HeightSize - ActualHeightOfLayers));
                return false;
            }
            else
            { ActualHeightOfLayers += layerHeightpom; }
            LayerGerne = int.Parse(tbLayerGerne.Text);
            isRandomPosition = IsRandom();
            Enum.TryParse(Sasiedztwo.SelectedValue.ToString(), out neighbourType);
            BoundaryConditionSelected = getBoundary();
            return true;
        }
   

        private BoundaryConditions getBoundary()
        {
            if (rdoAbsorb.Checked)
                return BoundaryConditions.Absorbing;
            else
                return BoundaryConditions.Periodic;
        }
       

        private async void Init()
        {
            Enum.TryParse(Sasiedztwo.SelectedValue.ToString(), out neighbourType);
            paintArea.Refresh();
            int.TryParse(TbWidth.Text, out widthSize);
            int.TryParse(tbHeight.Text, out heightSize);
            paintArea.Width = widthSize;
            paintArea.Height = heightSize;
            bmp = new Bitmap(WidthSize, HeightSize);
            gr = new Grid(HeightSize, WidthSize);
            paintArea.Width = WidthSize;
            paintArea.Height = HeightSize;
            paintArea.Image = bmp;
            ActualHeightOfLayers = 0;
          //  this.brushes = await SetupBrushes();
           
           
            

            graph = paintArea.CreateGraphics();
            graph.DrawImage(bmp, new Rectangle(0, 0, WidthSize, HeightSize), new Rectangle(0, 0, WidthSize, HeightSize), GraphicsUnit.Pixel);
            paintArea.Visible = true;

        }


        private void SetupBrushes()
        {
            // this.brushes =

            HashSet<SolidBrush> pedzle = new HashSet<SolidBrush>();
    
            int flaga = 0;
           

            Color previous = new Color();
            do
            {

                Color c = Color.FromArgb(RandomHelper.Next(0, 255), RandomHelper.Next(0, 255), RandomHelper.Next(0, 255));
                if (previous.Name == "0")
                {
                    previous = c;
                    pedzle.Add(new SolidBrush(c));
                }
                else
                {
                    if ((c.R - previous.R > 40 || c.R - previous.R < -40) && (c.G - previous.G > 40 || c.G - previous.G < -40) && (c.B - previous.B > 40 || c.B - previous.B < -40))
                    {
                        pedzle.Add(new SolidBrush(c));
                    }
                    else
                        continue;
                }




            } while (pedzle.Count() < WidthSize * HeightSize);
            this.brushes = pedzle.ToList();
           
        }


        private async Task<List<Brush>> SetupBrushesAsync()
        {
          

             HashSet<Brush> pedzle =    new HashSet<Brush>();
         
            int flaga = 0;
    
     
            Color previous = new Color();
            do
            {
                    
                    Color c = Color.FromArgb(RandomHelper.Next(0, 255), RandomHelper.Next(0, 255), RandomHelper.Next(0, 255));
                if (previous.Name == "0")
                {
                    previous = c;
                    pedzle.Add(new SolidBrush(c));
                }
                else
                {
                    if ((c.R - previous.R > 40 || c.R - previous.R < -40) && (c.G - previous.G > 40 || c.G -previous.G   < -40) && (c.B - previous.B > 40 || c.B - previous.B   < -40))
                    {
                        pedzle.Add(new SolidBrush(c));
                    }
                    else
                        continue;
                }
                

              

            } while (pedzle.Count() < WidthSize*HeightSize);

    
            return pedzle.ToList();
        }

    



 
        /// <summary>
        /// pobiera wszystkie mozliwe ziarna z pola o id == 0 i zapisuje do listy , aby w nastepnym kroku losowac miejsca polozenia ziaren.
        /// </summary>
        /// <param name="height"></param>
        public void FillList(int height, bool losowo = true)
        {
            nonUsedGrains.Clear();
            if (losowo)
            {
           
                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                Parallel.For(0, height, (i, ParallelLoopState) =>
                 {

                     for (int j = 0; j < WidthSize; j++)
                     {
                
                         if (gr.grid[i, j].isEmpty &&( gr.grid[i, j].X == 0 || Neighborhood.haveNeighborhood(gr.grid, i, j) ))
                         {
                             nonUsedGrains.Add(gr.grid[i, j]);
                         }
                         
                     }
  
                 });
            }
            else
            {
                bool flaga = true;
                int iteratorr = 0;
                int pomValue = (WidthSize - 1) / LayerGerne; 
                var watch1 = System.Diagnostics.Stopwatch.StartNew();
              

                    for (int i = 0; i < height; i++)
                    {


                
                            if (pomValue > WidthSize) pomValue = 0;
                        if (gr.grid[i, pomValue].isEmpty && (Neighborhood.haveNeighborhood(gr.grid, i, pomValue) || gr.grid[i, pomValue].X == 0))
                        {
                                nonUsedGrains.Add(gr.grid[i, pomValue]);
                                pomValue += (WidthSize) / LayerGerne;
                                  i = 0;
                                //  }



                                if (nonUsedGrains.Count == LayerGerne)
                                {

                                    break;
                                }
                            
                       // }
                    }
                    
                }
              
                
            }
        }


        public async  Task FillListAsync(int height, bool losowo = true)
        {
          ///  lblResult.Text = "Tworzenie zarodków.... ";
           // btnDraw.Enabled = false;
            nonUsedGrains.Clear();
            if (losowo)
            {

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                Parallel.For(0, height, (i, ParallelLoopState) =>
                {

                    for (int j = 0; j < WidthSize; j++)
                    {

                        if (gr.grid[i, j].isEmpty && (gr.grid[i, j].X == 0 || Neighborhood.haveNeighborhood(gr.grid, i, j)))
                        {
                            nonUsedGrains.Add(gr.grid[i, j]);
                        }

                    }
                
                });
            }
            else
            {
                bool flaga = true;
                int iteratorr = 0;
                int pomValue = (WidthSize - 1) / LayerGerne;
                var watch1 = System.Diagnostics.Stopwatch.StartNew();


                for (int i = 0; i < height; i++)
                {



                    if (pomValue > WidthSize) pomValue = 0;
                    if (gr.grid[i, pomValue].isEmpty && (Neighborhood.haveNeighborhood(gr.grid, i, pomValue) || gr.grid[i, pomValue].X == 0))
                    {
                        nonUsedGrains.Add(gr.grid[i, pomValue]);
                        pomValue += (WidthSize) / LayerGerne;
                        i = 0;
                        //  }



                        if (nonUsedGrains.Count == LayerGerne)
                        {

                            break;
                        }

                        // }
                    }

                }


            }
        }
        /// <summary>
        /// Generuje ziarna startowe
        /// </summary>
        public void FillOnStart(bool losowo = true)
        {
            nonUsedGrains.Clear();
            
            if(losowo)
            
            for (int i = 0; i < WidthSize; i++)
            {
                   nonUsedGrains.Add(gr.grid[0,i]);
            }
            else
            {
                int pom =  (WidthSize) / LayerGerne;
                for ( int i=0; i< LayerGerne ;i++)
                {
                    
                    if(pom == WidthSize) { pom = pom - 1; }
                    nonUsedGrains.Add(gr.grid[0, pom]);
                    pom += (WidthSize) / LayerGerne;


                }
                
            }
            
        }

        public async Task FillOnStartAsync(bool losowo = true)
        {
            nonUsedGrains.Clear();
           
           // btnDraw.Enabled = false;
            if (losowo)

                for (int i = 0; i < WidthSize; i++)
                {
                  nonUsedGrains.Add(gr.grid[0, i]);
                }
            else
            {
                int pom = (WidthSize) / LayerGerne;
                for (int i = 0; i < LayerGerne; i++)
                {

                    if (pom == WidthSize) { pom = pom - 1; }
                    nonUsedGrains.Add(gr.grid[0, pom]);
                    pom += (WidthSize) / LayerGerne;


                }

            }

        }

        /// <summary>
        /// losowanie miejsc ziaren
        /// </summary>

        public void InsertGerne(HashSet<Grain> list)
        {
            //lblActualWork.Text = "dodawanie ziaren";
            List<Grain> ListOfGrain = list.ToList();
            ActualLayerNumber += 1;
            if(list.Count == 0) return;

            if (HighestIdLayerValue == 0)
            {

                int number = 1;
                while (number <= LayerGerne)
                {
                    
                    Grain selectedGrain = ListOfGrain[RandomHelper.Next(0, ListOfGrain.Count)];
                    if (gr.grid[selectedGrain.X, selectedGrain.Y].ID == 0)
                    {
                        selectedGrain.numberOfLayer = ActualLayerNumber;
                        selectedGrain.ID = number;
                        
                        number++;
                        //  nonUsedGrains.Remove(coord);
                    }
                }

            }
            else
            {
                int number = 1;
                while (number <= LayerGerne)
                {
                    Grain selectedGrain = ListOfGrain[RandomHelper.Next(0, ListOfGrain.Count)];
                    if (gr.grid[selectedGrain.X, selectedGrain.Y].ID == 0)
                    {
                        selectedGrain.numberOfLayer = ActualLayerNumber;
                        selectedGrain.ID = number+HighestIdLayerValue;
                       
                        number++;
                        //  nonUsedGrains.Remove(coord);
                    }
                }

            }


            HighestIdLayerValue += LayerGerne;
        }





        public async Task InsertGerneAsync(HashSet<Grain> list)
        {
            //lblActualWork.Text = "dodawanie ziaren";
          //  btnDraw.Enabled = false;
            List<Grain> ListOfGrain = list.ToList();
            ActualLayerNumber += 1;
            if (list.Count == 0) return;

            if (HighestIdLayerValue == 0)
            {

                int number = 1;
                while (number <= LayerGerne)
                {

                    Grain selectedGrain = ListOfGrain[RandomHelper.Next(0, ListOfGrain.Count)];
                    if (gr.grid[selectedGrain.X, selectedGrain.Y].ID == 0)
                    {
                        selectedGrain.numberOfLayer = ActualLayerNumber;
                        selectedGrain.ID = number;

                        number++;
                        //  nonUsedGrains.Remove(coord);
                    }
                }

            }
            else
            {
                int number = 1;
                while (number <= LayerGerne)
                {
                    Grain selectedGrain = ListOfGrain[RandomHelper.Next(0, ListOfGrain.Count)];
                    if (gr.grid[selectedGrain.X, selectedGrain.Y].ID == 0)
                    {
                        selectedGrain.numberOfLayer = ActualLayerNumber;
                        selectedGrain.ID = number + HighestIdLayerValue;

                        number++;
                    
                    }
                }

            }


            HighestIdLayerValue += LayerGerne;
       
        }

        #endregion



        private void ClearValues()
        {
            ActualHeightOfLayers = 0;
            ActualLayerNumber = 0;
            flaga = 0;
            GC.Collect();
            gr = new Grid(HeightSize, WidthSize);
            bmp = new Bitmap(WidthSize, HeightSize);
            paintArea.Image = bmp;
        }

        private void btnDraw2_Click(object sender, EventArgs e)
        {
            if (!isHeightReached(ActualHeightOfLayers))
            {
                MessageBox.Show("Nie można aktualnie  rysować bez nowej warstwy");
            }
            else
            {
           
                if (isThreadAlive)
                    isThreadStarted = true;
                else
                {
                    isThreadStarted = true;
                    isThreadAlive = true;
                
                    growthThread = new Thread(new ThreadStart(MainThread));
              
                    growthThread.IsBackground = true;
                    growthThread.Start();
                    //   }

                   
                }
            }
        }

      

        private void Draw(Grain[,] grains, Grain[,] temp, int height)
        {
            Parallel.For(0, height, i =>
            {
                for (int j= 0; j < WidthSize; j++)
                {

                    if (grains[i, j] != temp[i, j])
                    {
                        lock (lockBrush)
                        {
                          //  using (Graphics graph = Graphics.FromImage(bmp))
                            {
                                try
                                {
                                    
                                    SolidBrush brush = brushes[grains[i, j].ID];
                                    bmp.SetPixel(j, i, brush.Color);
                                    //graph.FillRectangle(brush, j, i, 1, 1);
                                   
                                }
                                catch (Exception error)
                                {
                                 //   graph.Dispose();
                                   
                                }
                            }
                         
                        }
                    }

                }

            });
            paintArea.Invalidate();
          
        }

        

        


          


       

        private void CheckTextBoxesWidthHeight(object sender, EventArgs e)
        {
            int width;
            int height;
            int.TryParse(TbWidth.Text, out width);
            int.TryParse(tbHeight.Text, out height);
            paintArea.Width = width;
            paintArea.Height = height;
            btnInit.Enabled = true;
            //PanelThread.Enabled = false;
            btnInsert.Enabled = false;
        }
    }

}


