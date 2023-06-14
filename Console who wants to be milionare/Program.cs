

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    class Question
    {
        public string Text { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }
        public Type AnswerType { get; set; }
    }

    static void Main()
    {

        List<Question> questions = new()
        {
            new Question
            {
                Text = "Question 1: What is the capital of France?",
                Hint = "Hint: It's known as the 'City of Love'.",
                Answer = "Paris",
                AnswerType = typeof(string)
            },
            new Question
            {
                Text = "Question 2: Who painted the Mona Lisa?",
                Hint = "Hint: He was an Italian artist and polymath.",
                Answer = "da Vinci",
                AnswerType = typeof(string)
            },
            new Question
            {
                Text = "Question 3: How many millimeters are in a meter?",
                Hint = "Hint: As many as there meters in a kilometer.",
                Answer = "1000",
                AnswerType = typeof(int)
            },
        };

        Console.WriteLine("Welcome to the Polymath Quiz 'Who Wants to Be a Millionaire'!");
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"Hello, {userName}! Let's start the quiz.");

        int score = 0;
        int totalQuestions = questions.Count;
        const int quizTimeInSeconds = 60;
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();

        for (int i = 0; i < totalQuestions; i++)
        {
            Console.WriteLine(questions[i].Text);

            ManualResetEvent hintDisplayed = new ManualResetEvent(false);
            bool validInput = false;

            while (!validInput)
            {
                var readLineThread = new Thread(() =>
                {
                    Console.Write("Your answer: ");
                    string userAnswer = Console.ReadLine();

                    try
                    {
                        if (questions[i].AnswerType == typeof(int))
                        {
                            int parsedAnswer;
                            if (!int.TryParse(userAnswer, out parsedAnswer))
                            {
                                Console.WriteLine("Invalid input! Please provide a numeric answer.");
                                return;
                            }

                            if (parsedAnswer == int.Parse(questions[i].Answer))
                            {
                                Console.WriteLine("Correct!");
                                Interlocked.Increment(ref score);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect!");
                            }
                        }
                        else
                        {
                            if (userAnswer.Equals(questions[i].Answer, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Correct!");
                                Interlocked.Increment(ref score);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect!");
                            }
                        }

                        validInput = true; // Set validInput to true when the input is processed correctly
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    finally
                    {
                        hintDisplayed.Set(); // Signal that the user has answered
                    }
                });

                var hintThread = new Thread(() =>
                {
                    if (!hintDisplayed.WaitOne(5000)) // Wait for 5 seconds or until the user answers
                    {
                        Console.WriteLine(questions[i].Hint);
                    }
                });

                readLineThread.Start();
                hintThread.Start();

                readLineThread.Join(); // Wait for the user to enter their answer
                hintDisplayed.WaitOne(); // Wait for the hint to be displayed or user answers

                if (timer.Elapsed.TotalSeconds >= quizTimeInSeconds)
                {
                    Console.WriteLine("Time expired! Sorry, you didn't finish the quiz in time.");
                    break;
                }
            }
        }

        timer.Stop();

        Console.WriteLine($"Quiz completed! Your score: {score}/{totalQuestions}");
        Console.WriteLine($"You took around {timer.Elapsed.TotalSeconds} seconds to finish the quiz.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
