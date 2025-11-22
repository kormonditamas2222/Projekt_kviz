using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;
using System.Printing;

namespace kviz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand = new Random();


        private string nev;
        private Kerdes[] Kerdesek = new Kerdes[10];
        private int score = 0;
        private int progress = 0;


        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btn_nev_Click(object sender, RoutedEventArgs e)
        {
            nev = tbox_nev.Text.Trim();
            stack_start.Visibility = Visibility.Hidden;
            dock_quiz.Visibility = Visibility.Visible;

            get_questions();
            load_next_question();
        }

        private void get_questions()
        {
            List<Kerdes> all_questions = [];
            using (StreamReader reader = new StreamReader("../../../kerdesek.txt"))
            {
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    all_questions.Add(new Kerdes(
                        parts[0],
                        [
                            parts[1], parts[2], parts[3], parts[4]
                        ]
                    ));
                }
            }

            int[] numbers = Enumerable.Range(0, 10).ToArray();
            numbers = numbers.OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < 10; i++)
            {
                Kerdesek[i] = all_questions[numbers[i]];
            }
        }

        private void load_next_question()
        {
            if (progress == 10) {
                print_final();
                return;
            }
            Kerdes kerdes = Kerdesek[progress];
            kerdes.Shuffle();

            lb_szamlalo.Content = (progress + 1).ToString();

            tbox_kerdes.Text = kerdes.Question;

            btn_a.Content = kerdes.Answers[0];
            btn_b.Content = kerdes.Answers[1];
            btn_c.Content = kerdes.Answers[2];
            btn_d.Content = kerdes.Answers[3];
        }

        private void answer_btn_Click(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            int selected = int.Parse(pressed.Uid);
            if (selected == Kerdesek[progress].Correct) {
                score++;
            }

            progress++;
            load_next_question();
        }

        private void print_final()
        {
            tbox_eredmeny.Text = score.ToString();
            dock_quiz.Visibility = Visibility.Hidden;
            stack_end.Visibility = Visibility.Visible;
        }
    }
}