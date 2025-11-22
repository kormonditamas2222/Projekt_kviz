using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kviz
{
    class Kerdes
    {
        private Random rand = new Random();


        private string question;
        private string[] answers;
        private int correct;

        public Kerdes(string question, string[] answers)
        {
            this.question = question;
            this.answers = answers;
            this.correct = 0;
        }

        public string Question { get => question; }
        public string[] Answers { get => answers; }
        public int Correct { get => correct; }

        public void Shuffle() {
            int[] numbers = Enumerable.Range(0, 4).ToArray();
            numbers = numbers.OrderBy(x => rand.Next()).ToArray();

            List<string> newlist = [];
            foreach (int i in numbers)
            {
                newlist.Add(answers[i]);
                if (i == 0)
                {
                    correct = newlist.Count()-1;
                }
            }
            answers = newlist.ToArray();
        }
    }
}
