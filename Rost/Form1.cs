using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Gumilev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         //   public TheVal1;
        }

        public double TheVal;
        public double Valx1;
        public double Valx2;
       

        //Объяснение для второй задачи:
        // M - еденица мощности, на которой производится продукт
        // R - общее число занятых работников
        // x - число работников на еденице мощности
        // Y - нац.продукт.
        // M0,R0 - нач значения, t - время.
        // alp,alpha - коэффициент прироста занятых работников
        // bt,beta - коэффициент выбытия мощностей (износ)
        // gm, gamma - коэффициент времени, требуемого на ввод новых мощностей.


        //ДОП.
        //Следует так же иметь ввиду, что функция Y рассчитывается
        //по принципу f(x) =x, т.к. f(x) трудно формализуема.
        //
        //

        //константы
      //  

        //функции рассчета точек МОДЕЛИ

        //для данной задачи


        /*
        //возвращает график развития гос-ва (структуры)
        double o1(double a, double x1, double l1, double y1, double k1)
        {
            return (a * x1 + l1 * y1 - k1 * Math.Pow(y1,2));
        }

        //возвращает график развития экономики
        double o2(double a, double x1, double l2, double y1, double k2)
        {
            return (a * y1 - l2 * x1 + k2 * Math.Pow(x1, 2));
        }
        */

        //МОДЕЛЬ РОСТА
        double o3(double M0, double gm, double bt, double t, double R0, double alp)
        {
            double M = M0 * Math.Exp(((gm - bt) * t));
            double R = R0 * Math.Exp(alp * t);

            double x = R / M;

            //т.к. функция определена на 0<x<xM
            double funx =Math.Abs( Math.Sin(x));

            double Y = M * funx;

            return Y;


        }


        
      //КРИВАЯ M
        double oM(double M0,double gm,double bt, double t)
        {
            double M = M0 * Math.Exp(((gm - bt) * t));
            return M;
        }
        
        //КРИВАЯ R
        double oR(double R0, double alp, double t)
        {
            double R = R0 * Math.Exp(alp * t);
            return R;
        }


        //функция рисования ГРАФИКА

     
        //задача2
        void DrawGraph11(double M0, double R0, double alp, double bt, double gm)
        {

            
            //Выполнил Пономарев С.А.

            //Правила




            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.XAxis.Title.Text = "t, Время";
            pane.YAxis.Title.Text = "Y, Экономический рост";
            pane.Title.Text = "Модель экономического роста";

            // Очистим компонент
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList tr_list = new PointPairList();
            PointPairList tr_list2 = new PointPairList();
                   PointPairList tr_list3 = new PointPairList();

            double xmin = 0;
            double xmax = 5;

            /*
            double ymin = -5;
            double ymax = 5;
            */


            /*
                //Двойной
                // Заполняем список точек
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    for (double y = ymin; y <= ymax; y += 0.01)
                    {
                        // добавим в список точку

                        //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                        tr_list.Add(x, o1(a, x, l1, y, k1));

                        tr_list2.Add(y, o2(a, x, l2, y, k2));
                        //orig
                        //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                        //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
                    }
                }
                */



            //Т.к. мы строим зависимость от времени, то график будет строится по x.
            // x в данном случае равен t.

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку

                //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                tr_list.Add(x, o3(M0,gm,bt,x,R0,alp));
                tr_list2.Add(x, oM(M0,gm,bt,x));
                tr_list3.Add(x, oR(R0,alp,x));
                //orig
                //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
            }

    



            /*
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                tr_list3.Add(x, n);
            }
              */

            // Создадим кривую 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve1 = pane.AddCurve("Экономический рост", tr_list, Color.Blue, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("мощность", tr_list2, Color.Green, SymbolType.None);
            LineItem myCurve3 = pane.AddCurve("численность рабочих", tr_list3, Color.Red, SymbolType.None);
          //  LineItem myCurve2 = pane.AddCurve("Развитие экономики", tr_list2, Color.Green, SymbolType.None);

            //      LineItem myCurve3 = pane.AddCurve("Минимально допустимый уровень лекарства", tr_list3, Color.Red, SymbolType.None);

            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();




        }





       

        //Функция загрузки формы
        //и чего-то еще
        // и еще чего-то еще
        private void Form1_Load(object sender, EventArgs e)
        {
            //Первый таб
            //ВВОДИМ ПЕРЕМЕНЫЕ

           // double m = trackBar11.Value * 0.001;

         //   double a = trackBar1.Value;


            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();


            /*
            double l2 = Convert.ToDouble(trackBar6.Value);
            groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            groupBox7.Text = "коэффициент вливания капитала в экономику= " + k2.ToString();
            */


            /*
            double a = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Пассионарная напряженность= " + a.ToString();

            double x1 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();

            double y1 = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            groupBox7.Text = "коэффициент вливания капитала в экономику= " + k2.ToString();
            */


            //Отрисовываем графы
            //первый граф
           // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);
           // DrawGraph11(a, x1, y1, l1, l2, k1, k2);

          

            label1.Text = "В задаче представлена модель экономического роста с синусоидной производственной функцией ";
            label2.Text = "Выполнил Пономарев С.А.";
            label4.Text = "Y - производимый продукт, R - число занятых работников, M - задействованные мощности \n M0-мощность в начальный момент времени, R0-количество работников в начальный момент времени, \n далее коэффициенты альфа бета и гамма соответственно \n  ";

            label3.Text = " Y(t)=M(t) * f(x(t)), M(t) = M0^((gamma-beta)*t), x(t)=R(t)/M(t), \n f(x)=Abs(Sin(x)) - Sin как пример, Abs - т.к. должна быть определена на 0<x<xM \n R(t)=R0*exp(alpha*t) ";

        }


 //В ходе работы на данной программой возник баг при отрисовке графика на табе
        //в результате которого слелети бинды (bind) к скроллам, поэтому функция trackBar1_Scroll
        //была переписана и перенесена в конец кода


        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();



           // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
         //   label1.Text = "";


       //     label1.Text = "Темпы экономического роста Y во многом зависят от M0 и R0";
            label2.Text = "Количество занятых работников в начальный момент времени";
            label1.Text = "В развивающейся экономике число рабочих растет экспоненциально с коэффициентом альфа.";


            if ((gm - bt) == alp && M0==R0)
                label1.Text = "Кривые M и R равны,т.к. число рабочих растет в той же пропорции, что и ввод новых мощностей \n Y(t) ограничен ими";
            if ((gm - bt) > alp)
                label1.Text = "Экспоненциальный рост мощности значительно превышает такой же рост рабочих, рост отсутствует, т.к.мощности простаивают";
            if ((gm - bt) < alp)
                label1.Text = "Экспоненциальный рост рабочих значительно превышает такой же рост мощностей. Рост отсутствует";
            if ((gm - bt) == alp && M0 > R0)
                label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";
            if ((gm - bt) == alp && M0 < R0)
                label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";


            label1.Text = "коэффициент альфа определяет с какой скоростью растет количество рабочих";
        //    label2.Text = "Количество занятых работников в начальный момент времени";
            label2.Text = "В развивающейся экономике число рабочих растет экспоненциально с коэффициентом альфа.";

            if ((gm - bt) == alp && M0 == R0)
                label1.Text = "Кривые M и R равны,т.к. число рабочих растет в той же пропорции, что и ввод новых мощностей \n Y(t) ограничен ими";
            if ((gm - bt) > alp)
                label1.Text = "Экспоненциальный рост мощности значительно превышает такой же рост рабочих, рост отсутствует, т.к.мощности простаивают";
            if ((gm - bt) < alp)
                label1.Text = "Экспоненциальный рост рабочих значительно превышает такой же рост мощностей. Рост отсутствует";
            if ((gm - bt) == alp && M0 > R0)
                label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";
            if ((gm - bt) == alp && M0 < R0)
                label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";

    //        label2.Text = "Коэффицет износа мощностей.";
            label2.Text = "коэффициент бета, определяющий скорость выбытия мощностей";
            if (bt == gm)
                label1.Text = "Функция мощностей M(t)=M0^((гамма-бета)*t), соответственно если темп выбытия мощностей будет равен темпу введения новых в эксплуатацию,\n то рост прекратится";

          //  else
                if (bt > gm)
                    label1.Text = "Мощности выходят из строя быстрее, чем создаются новые, рост отрицателен ";
                if ((gm - bt) > alp)
                    label1.Text = "Экспоненциальный рост мощности значительно превышает такой же рост рабочих, рост отсутствует, т.к.мощности простаивают";




                if ((gm - bt) == alp && M0 == R0)
                    label1.Text = "Кривые M и R равны,т.к. число рабочих растет в той же пропорции, что и ввод новых мощностей \n Y(t) ограничен ими";


                //    else
                if ((gm - bt) == alp && M0 > R0)
                    label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";

                //        else
                if ((gm - bt) == alp && M0 < R0)
                    label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";
            

                /*
                else
                    label1.Text = "Хуяк!";
                 * /
                 
                 
                /*
            if ((gm - bt) == alp && M0 > R0)
                label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";
            if ((gm - bt) == alp && M0 < R0)
                label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";
                */

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";

            label2.Text = "коэффициент ввода новых мощностей в эксплуатацию";
      //      label1.Text = "";
            if (gm == bt)
                label1.Text = "Функция мощностей M(t)=M0^((гамма-бета)*t), соответственно если темп выбытия мощностей будет равен темпу введения новых в эксплуатацию,\n то рост прекратится";
          //  else
            if (bt > gm)
                label1.Text = "Мощности выходят из строя быстрее, чем создаются новые, рост отрицателен ";

            if ((gm - bt) > alp)
                label1.Text = "Экспоненциальный рост мощности значительно превышает такой же рост рабочих, рост отсутствует, т.к.мощности простаивают";
           



            if ((gm - bt) == alp && M0 == R0)
                label1.Text = "Кривые M и R равны,т.к. число рабочих растет в той же пропорции, что и ввод новых мощностей \n Y(t) ограничен ими";


        //    else
                if ((gm - bt) == alp && M0 > R0)
                label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";
            
        //        else
            if ((gm - bt) == alp && M0 < R0)
                label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";
            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }



        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
             TheVal = Convert.ToDouble(trackBar1.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Valx1 = Convert.ToDouble(trackBar2.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            Valx2 = Convert.ToDouble(trackBar3.Value);
        }

        
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {

            //МОЩНОСТЬ М0


            // образец функции убывания/увеличивания значения трекбара!!!
            /*
            if (a < TheVal)
                label1.Text = "a убывает";
            if (a > TheVal)
                label1.Text = "a растет";
            */

            /*
            if (a < TheVal)
                label1.Text = "Большая пассионарная напряженность увеличивает скорость процессов развития";
            if (a > TheVal)
                label1.Text = "Меньшая пассионарная напряженность уменьшает скорость процессов развития";
            */




            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();




            /*
            if (a > 0)
                label2.Text = "При положительных значениях A наблюдается склонность к развитию процессов";
            if (a < 0)
                label2.Text = "При отрицательных значениях наблюдается склонность к разложению";
        */


            /*
            else
                label1.Text = "";
            label2.Text = "";
            */

            //    label1.Text = "Темпы экономического роста Y во многом зависят от M0 и R0";

            label1.Text = "Функция мощности M(t) является верхним пределом функции роста Y(t)";

            label2.Text = "Мощность в начальный момент времени";

            if ((gm - bt) == alp && M0 == R0)
                label1.Text = "Кривые M и R равны,т.к. число рабочих растет в той же пропорции, что и ввод новых мощностей, Y(t) ограничен ими";
            if ((gm - bt) > alp)
                label1.Text = "Экспоненциальный рост мощности значительно превышает такой же рост рабочих, рост отсутствует, т.к.мощности простаивают";
            if ((gm - bt) < alp)
                label1.Text = "Экспоненциальный рост рабочих значительно превышает такой же рост мощностей. Рост отсутствует";
            if ((gm - bt) == alp && M0 > R0)
                label1.Text = "Рост мощностей незначительно опережает рост рабочих, производительность ограничена количеством рабочих";
            if ((gm - bt) == alp && M0 < R0)
                label1.Text = "В быстро развивающейся экономике рост рабочих опережает рост мощностей, производительность ограничена количеством мощностей и не значительно колебается в этих пределах в зависимости от производственной функции";



            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);
            //  DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 2;
            trackBar2.Value = 2;
            trackBar3.Value = 1;
            trackBar4.Value = 3;
            trackBar5.Value = 4;

            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "коэффициент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "коэффициент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "коэффициент времени ввода новых мощностей" + gm.ToString();

            DrawGraph11(M0, R0, alp, bt, gm);

            label1.Text = "В задаче представлена модель экономического роста с синусоидной производственной функцией (в случае линейной функции Y всегда будет равен R";
            label2.Text = "Выполнил Пономарев С.А.";
            label4.Text = "В качестве примера рассматривается модель когда дельта между коэффициентом ввода мощностей и коэффициентом вывода мощностей = 1, что в свою очередь равно коэффициенту прироста рабочих , а начальная мощность и кол-во рабочих равны 2. \n В таком случае Y(t)достигает максимума равного 250";

            label3.Text = " Y(t)=M(t) * f(x(t)), M(t) = M0^((gamma-beta)*t), x(t)=R(t)/M(t), \n f(x)=Abs(Sin(x)) - Sin как пример, Abs - т.к. должна быть определена на 0<x<xM \n R(t)=R0*exp(alpha*t) ";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "135")
                MessageBox.Show("Правильный ответ! при текущем R0=2 и M0=1 ответ всегда будет 135, пока разница коэффициентов гамма и бета будут равны коэффициенту альфа равному '1' ");
            else
                MessageBox.Show("Неправильный ответ!, правильный ответ '135'");
        }
        
        






    }

}
