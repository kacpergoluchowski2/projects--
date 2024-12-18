using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.VievModels
{
    public class Question : BindableObject
    {
        public string QuestionContent { get; set; }
        private ObservableCollection<Answer> answers;

        public ObservableCollection<Answer> Answers 
        {
            get { return answers; }
            set { answers = value;  OnPropertyChanged(); }
        }
    }

    public class Answer : BindableObject
    {
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }

        public bool isCorrect { get; set; }

        private string answerContent;

        public string AnswerContent
        {
            get { return answerContent; }
            set { answerContent = value; OnPropertyChanged(); }
        }
    }

    internal class QuizVievModel : BindableObject
    {
        Question question1 = new Question
        {
            QuestionContent = "Jaki typ danych w języku C# przechowuje liczby całkowite?",
            Answers = new ObservableCollection<Answer>()
            {
                new Answer()
                {
                    AnswerContent = "string",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "int",
                    IsSelected = false,
                    isCorrect = true
                },
                new Answer()
                {
                    AnswerContent = "float",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "char",
                    IsSelected = false,
                    isCorrect = false
                }
            }
        };

        Question question2 = new Question
        {
            QuestionContent = "Który z poniższych operatorów w języku Python służy do porównania dwóch wartości?",
            Answers = new ObservableCollection<Answer>()
            {
                new Answer()
                {
                    AnswerContent = "==",
                    IsSelected = false,
                    isCorrect = true
                },
                new Answer()
                {
                    AnswerContent = "=",
                    IsSelected = true,
                    isCorrect = true
                },
                new Answer()
                {
                    AnswerContent = "!==",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "=>",
                    IsSelected = false,
                    isCorrect = false
                }
            }
        };

        Question question3 = new Question
        {
            QuestionContent = "Co oznacza pojęcie \"polimorfizm\" w programowaniu obiektowym?",
            Answers = new ObservableCollection<Answer>()
            {
                new Answer()
                {
                    AnswerContent = "Możliwość tworzenia nowych klas w ramach istniejących klas",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "Możliwość definiowania wielu metod o tej samej nazwie w jednej klasie",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "Możliwość przypisania różnych implementacji tej samej metody w różnych klasach",
                    IsSelected = false,
                    isCorrect = true
                },
                new Answer()
                {
                    AnswerContent = "Możliwość tworzenia zmiennych o zmieniającym się typie w czasie działania programu",
                    IsSelected = false,
                    isCorrect = false
                }
            }
        };

        Question question4 = new Question
        {
            QuestionContent = "Jakie słowo kluczowe w języku C++ służy do deklaracji zmiennej, która nie może zostać zmieniona po jej inicjalizacji?",
            Answers = new ObservableCollection<Answer>()
            {
                new Answer()
                {
                    AnswerContent = "static",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "const",
                    IsSelected = false,
                    isCorrect = true
                },
                new Answer()
                {
                    AnswerContent = "final",
                    IsSelected = false,
                    isCorrect = false
                },
                new Answer()
                {
                    AnswerContent = "immutable",
                    IsSelected = false,
                    isCorrect = false
                }
            } 
        };

        private ObservableCollection<Question> questions;

        public ObservableCollection<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }


        private string questionLabel;
        public string QuestionLabel
        {
            get { return questionLabel; }
            set { questionLabel = value; OnPropertyChanged(); }
        }

        private string answer1Label;
        public string Answer1Label
        {
            get { return answer1Label; }
            set { answer1Label = value; OnPropertyChanged(); }
        }

        private string answer2Label;
        public string Answer2Label
        {
            get { return answer2Label; }
            set { answer2Label = value; OnPropertyChanged(); }
        }

        private string answer3Label;
        public string Answer3Label
        {
            get { return answer3Label; }
            set { answer3Label = value; OnPropertyChanged(); }
        }

        private string answer4Label;

        public string Answer4Label
        {
            get { return answer4Label; }
            set { answer4Label = value; OnPropertyChanged(); }
        }

        private Command nextQuestionCommand;

        public Command NextQusetionCommand
        {
            get { return nextQuestionCommand; }
            set { nextQuestionCommand = value; }
        }

        private Command previousQuestionCommand;

        public Command PreviousQuestionCommand
        {
            get { return previousQuestionCommand; }
            set { previousQuestionCommand = value; }
        }


        private Command selectAnswerCommand;

        public Command SelectAnswerCommand
        {
            get { return selectAnswerCommand; }
            set { selectAnswerCommand = value; }
        }

        private bool answer1RadioButton;

        public bool Answer1RadioButton
        {
            get { return answer1RadioButton; }
            set { answer1RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer2RadioButton;

        public bool Answer2RadioButton
        {
            get { return answer2RadioButton; }
            set { answer2RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer3RadioButton;

        public bool Answer3RadioButton
        {
            get { return answer3RadioButton; }
            set { answer3RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer4RadioButton;

        public bool Answer4RadioButton
        {
            get { return answer4RadioButton; }
            set { answer4RadioButton = value; OnPropertyChanged(); }
        }

        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        private Color resultColor;

        public Color ResultColor
        {
            get { return resultColor; }
            set { resultColor = value; OnPropertyChanged(); }
        }

        public int currentQuestionIndex { get; set; }         

        public QuizVievModel()
        {
            currentQuestionIndex = 0;
            Questions = { question1, question2, question3, question4 };

            void DisplayQuestionAndAnswers()
            {
                QuestionLabel = Questions[currentQuestionIndex].QuestionContent;

                Answer1Label = questions[currentQuestionIndex].Answers[0].AnswerContent;
                Answer2Label = questions[currentQuestionIndex].Answers[1].AnswerContent;
                Answer3Label = questions[currentQuestionIndex].Answers[2].AnswerContent;
                Answer4Label = questions[currentQuestionIndex].Answers[3].AnswerContent;

                Answer1RadioButton = questions[currentQuestionIndex].Answers[0].IsSelected;
                Answer2RadioButton = questions[currentQuestionIndex].Answers[1].IsSelected;
                Answer3RadioButton = questions[currentQuestionIndex].Answers[2].IsSelected;
                Answer4RadioButton = questions[currentQuestionIndex].Answers[3].IsSelected;


            }

            NextQusetionCommand = new Command(() =>
            {
                currentQuestionIndex++;
                DisplayQuestionAndAnswers();
            });

            DisplayQuestionAndAnswers();
        }
    }
}
