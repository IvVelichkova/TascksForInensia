namespace Tasks_for_Inensia
{

    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var title = "f1";
            var t = new Survey(title);
            t.AddQestion(new TextQesstion { Label = "How Old Are You?" });
            t.AddQestion(new TextQesstion { Label = "Whats your Name?" });
            t.PrintScore();

        }
    }

    public abstract class Answer
    {
        public int Score { get; set; }
    }

    public abstract class Question
    {
        public string Label { get; set; }

        protected abstract Answer CreateAnswer(string input);
        protected virtual void PrintQuestion()
        {
            Console.WriteLine(this.Label);
        }

        public Answer Ask()

        {
            PrintQuestion();

            var input = Console.ReadLine();
            return CreateAnswer(input);

        }
    }

    public class TextAnswer : Answer
    {

        public string Text { get; set; }
    }

    public class TextQesstion : Question
    {
        protected override Answer CreateAnswer(string input)
        {
            return new TextAnswer { Text = input, Score = input.Length };
        }
    }

    public class Survey
    {
        private string title;
        public Survey(string title)
        {
            Title = title;
            this.Questions = new List<Question>();
        }
        public string Title { get; set; }

        public List<Question> Questions { get; private set; }

        public void AddQestion(Question qst)
        {
            this.Questions.Add(qst);
        }

        public int GetScore()
        {
            int total = 0;
            foreach (var question in this.Questions)
            {
                Answer answer = question.Ask();
                total += answer.Score;
            }
            return total;
        }
        public void PrintScore()
        {
            var total = GetScore();
            Console.WriteLine($"Your score: {total}");
        }

    }
}