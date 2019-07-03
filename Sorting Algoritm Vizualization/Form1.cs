using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_Algoritm_Vizualization
{
    public partial class Sorting_Form : Form
    {
        private List<Rectangle> DataToSort = new List<Rectangle>();
        private List<Rectangle> OldDataToSort = new List<Rectangle>();
        private bool algorithm_choosen = false;
        private bool hasShuffled = false;
        private bool sortingOnGoing = false;

        Stopwatch stopWatch = new Stopwatch();

        public Sorting_Form()
        {
            InitializeComponent();
            new Settings();

            //Setting the timer
            timer.Interval = 1000 / Settings.Speed;
            timer.Tick += UpdateScreen;
            timer.Start();
            
            StartGame();
        }

        public void StartGame() {
            //Set the default settings
            new Settings();
            lb_complete.Visible = false;
            algorithm_name.Visible = false;
            algorithm_choosen = false;
            Settings.Completed = false;
            sortingOnGoing = false;
            lb_elapsed_time.Visible = false;
            value_elapsed_time.Visible = false;

            //Create the data to sort
            DataToSort.Clear();
            Random rand = new Random();
            for (int i=0; i<50; i++)
            {
                int Heigth = rand.Next(5, 500);
                Rectangle rectangle = new Rectangle((int)(i * Settings.Width) + 5 + i * 3, 500-Heigth, Heigth);
                DataToSort.Add(rectangle);
                OldDataToSort.Add(rectangle);
            }
            hasShuffled = true;

            //Create the algorithm selecting label
            string algorithm_selector = "Please select a sorting\nalgorithm, by pressing\none of the following\nnumber!\n 1: Quick Sort\n 2: Bubble Sort\n 3: Selection Sort\n 4: Insertion Sort\n 5: Shell Sort";
            lb_algorithm_selector.Text = algorithm_selector;
        }

        public async void UpdateScreen(object sender, EventArgs e)
        {
            if ((Input.KeyPressDetect(Keys.D1) || Input.KeyPressDetect(Keys.NumPad1)) && algorithm_choosen == false && sortingOnGoing == false)
            {
                if (hasShuffled == false)
                {
                    StartGame();
                    p_canvas.Refresh();
                }
                algorithm_choosen = true;
                algorithm_name.Text = "Quick sort";
                algorithm_name.Visible = true;
                lb_algorithm_selector.Visible = false;
                sortingOnGoing = true;

                //Make a stapwatch
                stopWatch.Reset();
                stopWatch.Start();

                //Set stopwatch labels visible
                lb_elapsed_time.Visible = true;
                value_elapsed_time.Visible = true;
                
                //Run the algorithm
                await Task.Run(() => QuickSort(DataToSort, 0, 49));
                hasShuffled = false;
            }

            if ((Input.KeyPressDetect(Keys.D2) || Input.KeyPressDetect(Keys.NumPad2)) && algorithm_choosen == false && sortingOnGoing == false)
            {
                if (hasShuffled == false)
                {
                    StartGame();
                    p_canvas.Refresh();
                }
                algorithm_choosen = true;
                algorithm_name.Text = "Bubble Sort";
                algorithm_name.Visible = true;
                lb_algorithm_selector.Visible = false;
                sortingOnGoing = true;

                //Make a stapwatch
                stopWatch.Reset();
                stopWatch.Start();

                //Set stopwatch labels visible
                lb_elapsed_time.Visible = true;
                value_elapsed_time.Visible = true;

                //Run the algorithm
                await Task.Run(() => BubbleSort());
                hasShuffled = false;
            }

            if ((Input.KeyPressDetect(Keys.D3) || Input.KeyPressDetect(Keys.NumPad3)) && algorithm_choosen == false && sortingOnGoing == false)
            {
                if (hasShuffled == false)
                {
                    StartGame();
                    p_canvas.Refresh();
                }
                algorithm_choosen = true;
                algorithm_name.Text = "Selection Sort";
                algorithm_name.Visible = true;
                lb_algorithm_selector.Visible = false;
                sortingOnGoing = true;

                //Make a stapwatch
                stopWatch.Reset();
                stopWatch.Start();

                //Set stopwatch labels visible
                lb_elapsed_time.Visible = true;
                value_elapsed_time.Visible = true;

                //Run the algorithm
                await Task.Run(() => SelectionSort());
                hasShuffled = false;
            }

            if ((Input.KeyPressDetect(Keys.D4) || Input.KeyPressDetect(Keys.NumPad4)) && algorithm_choosen == false && sortingOnGoing == false)
            {
                if (hasShuffled == false)
                {
                    StartGame();
                    p_canvas.Refresh();
                }
                algorithm_choosen = true;
                algorithm_name.Text = "Insertion Sort";
                algorithm_name.Visible = true;
                lb_algorithm_selector.Visible = false;
                sortingOnGoing = true;

                //Make a stapwatch
                stopWatch.Reset();
                stopWatch.Start();

                //Set stopwatch labels visible
                lb_elapsed_time.Visible = true;
                value_elapsed_time.Visible = true;

                //Run the algorithm
                await Task.Run(() => InsertionSort());
                hasShuffled = false;
            }

            if ((Input.KeyPressDetect(Keys.D5) || Input.KeyPressDetect(Keys.NumPad5)) && algorithm_choosen == false && sortingOnGoing == false)
            {
                if (hasShuffled == false)
                {
                    StartGame();
                    p_canvas.Refresh();
                }
                algorithm_choosen = true;
                algorithm_name.Text = "Shell Sort";
                algorithm_name.Visible = true;
                lb_algorithm_selector.Visible = false;
                sortingOnGoing = true;

                //Make a stapwatch
                stopWatch.Reset();
                stopWatch.Start();

                //Set stopwatch labels visible
                lb_elapsed_time.Visible = true;
                value_elapsed_time.Visible = true;

                //Run the algorithm
                await Task.Run(() => ShellSortBetter());
                hasShuffled = false;
            }

            TimeSpan ts = stopWatch.Elapsed;
            value_elapsed_time.Text = String.Format("{0:00}.{1:000} seconds", ts.Seconds, ts.Milliseconds / 10);

            p_canvas.Refresh();
        }

        private void QuickSort(List<Rectangle> Data, int start, int end)
        {
            int i;
            int GoodPlaceCounter = 0;
            if (start < end)
            {
                i = Partition(Data, start, end);

                QuickSort(Data, start, i - 1);
                QuickSort(Data, i + 1, end);
            }

            for (int j=0; j<Data.Count()-1; j++)
            {
                if (Data[j].getHeigth() <= Data[j+1].getHeigth())
                {
                    GoodPlaceCounter++;
                    if (GoodPlaceCounter == 47)
                    {
                        GoodPlaceCounter = 0;
                        Settings.Completed = true;
                        sortingOnGoing = false;
                        stopWatch.Stop();
                    }
                }
            }
        }

        private int Partition(List<Rectangle> Data, int start, int end)
        {
            Rectangle temp = new Rectangle(0,0,0);
            Rectangle p = new Rectangle(0,0,0);
            p = Data[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (Data[j].getHeigth() <= p.getHeigth())
                {
                    i++;
                    temp = Data[i];
                    Data[i] = Data[j];
                    Data[j] = temp;
                    System.Threading.Thread.Sleep(40);
                }
            }

            temp = Data[i + 1];
            Data[i + 1] = Data[end];
            Data[end] = temp;
            System.Threading.Thread.Sleep(40);
            return i + 1;
        }

        private void BubbleSort()
        {
            Rectangle temp = new Rectangle(0,0,0);

            for (int write = 0; write < DataToSort.Count(); write++)
            {
                for (int sort = 0; sort < DataToSort.Count() - 1; sort++)
                {
                    if (DataToSort[sort].getHeigth() > DataToSort[sort + 1].getHeigth())
                    {
                        temp = DataToSort[sort + 1].ShallowCopy();
                        DataToSort[sort + 1] = DataToSort[sort].ShallowCopy();
                        DataToSort[sort] = temp.ShallowCopy();
                        System.Threading.Thread.Sleep(40);
                    }
                }
            }
            Settings.Completed = true;
            sortingOnGoing = false;
            stopWatch.Stop();
        }

        private void SelectionSort()
        {
            int i;
            int N = DataToSort.Count();
            Rectangle temp = new Rectangle(0, 0, 0);

            for (i = 0; i < N - 1; i++)
            {
                int k = IntArrayMin(DataToSort, i);
                if (i != k)
                    temp = DataToSort[k].ShallowCopy();
                    DataToSort[k] = DataToSort[i].ShallowCopy();
                    DataToSort[i] = temp.ShallowCopy();
                    System.Threading.Thread.Sleep(40);
            }
            Settings.Completed = true;
            sortingOnGoing = false;
            stopWatch.Stop();
        }

        private int IntArrayMin(List<Rectangle> Data, int start)
        {
            int minPos = start;
            for (int pos = start + 1; pos < Data.Count(); pos++)
                if (Data[pos].getHeigth() < Data[minPos].getHeigth())
                    minPos = pos;
            return minPos;
        }

        private void InsertionSort()
        {
            int i, j;
            int N = DataToSort.Count();
            Rectangle temp = new Rectangle(0, 0, 0);

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && DataToSort[i].getHeigth() < DataToSort[i - 1].getHeigth(); i--)
                {
                    temp = DataToSort[i].ShallowCopy();
                    DataToSort[i] = DataToSort[i-1].ShallowCopy();
                    DataToSort[i-1] = temp.ShallowCopy();
                    System.Threading.Thread.Sleep(40);
                }
            }
            Settings.Completed = true;
            sortingOnGoing = false;
            stopWatch.Stop();
        }

        private int[] GenerateIntervals(int n)
        {
            if (n < 2)
            {  // no sorting will be needed
                return new int[0];
            }
            int t = Math.Max(1, (int)Math.Log(n, 3) - 1);
            int[] intervals = new int[t];
            intervals[0] = 1;
            for (int i = 1; i < t; i++)
                intervals[i] = 3 * intervals[i - 1] + 1;
            return intervals;
        }

        private void ShellSortBetter()
        {
            int[] intervals = GenerateIntervals(DataToSort.Count());
            ShellSort(DataToSort, intervals);
        }

        private void ShellSort(List<Rectangle> Data, int[] intervals)
        {
            int i, j, k, m;
            int N = Data.Count();
            Rectangle temp = new Rectangle(0, 0, 0);

            // The intervals for the shell sort must be sorted, ascending

            for (k = intervals.Length - 1; k >= 0; k--)
            {
                int interval = intervals[k];
                for (m = 0; m < interval; m++)
                {
                    for (j = m + interval; j < N; j += interval)
                    {
                        for (i = j; i >= interval && Data[i].getHeigth() < Data[i - interval].getHeigth(); i -= interval)
                        {
                            temp = DataToSort[i].ShallowCopy();
                            DataToSort[i] = DataToSort[i - interval].ShallowCopy();
                            DataToSort[i - interval] = temp.ShallowCopy();
                            System.Threading.Thread.Sleep(40);
                        }
                    }
                }
            }
            Settings.Completed = true;
            sortingOnGoing = false;
            stopWatch.Stop();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Paint_Event(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            //Draw the data to sort
            for (int i = 0; i < DataToSort.Count(); i++)
            {
               if (OldDataToSort[i].getX() != DataToSort[i].getX())
               {
                    canvas.FillRectangle(Brushes.Red, (int)(i * Settings.Width) + 5 + i * 3, DataToSort[i].getY(), Settings.Width, DataToSort[i].getHeigth());
               }
                else
                {
                    canvas.FillRectangle(Brushes.Black, (int)(i * Settings.Width) + 5 + i * 3, DataToSort[i].getY(), Settings.Width, DataToSort[i].getHeigth());
                }

                if (Settings.Completed == true)
                {
                    lb_complete.Visible = true;
                    lb_algorithm_selector.Visible = true;
                    hasShuffled = false;
                    algorithm_choosen = false;
                }
            }

            for (int i = 0; i < DataToSort.Count(); i++)
            {
                OldDataToSort[i] = DataToSort[i];
            }
        }
    }
}
