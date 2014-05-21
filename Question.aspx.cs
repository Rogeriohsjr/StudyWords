using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyWords
{
    public partial class Question : System.Web.UI.Page
    {
        ManagerQuestion _objManager;
        private ManagerQuestion glbManagerQuestion
        {
            get
            {
                if (_objManager == null)
                {
                    _objManager = (ManagerQuestion)Session["ManagerQuestion"];
                }

                return _objManager;
            }

            set
            {
                _objManager = value;
                Session.Remove("ManagerQuestion");
                Session["ManagerQuestion"] = _objManager;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClick_btLoadQuestion(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            ManagerQuestion objManager = new ManagerQuestion();
            objManager.GenerateQuestion(out sMessage);

            glbManagerQuestion = objManager;

            QuestionClass objQuestionClass = glbManagerQuestion.GetCurrentQuestion(out sMessage);
            FillScreen(objQuestionClass, out sMessage);
        }

        protected void btNext_OnClick(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            QuestionClass objQuestionClass = new QuestionClass();

            objQuestionClass = glbManagerQuestion.GetCurrentQuestion(out sMessage);
            GetDataScreen(objQuestionClass, out sMessage);

            objQuestionClass = glbManagerQuestion.NextQuestion(out sMessage);
            FillScreen(objQuestionClass, out sMessage);
        }

        protected void btPrevious_OnClick(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            QuestionClass objQuestionClass = new QuestionClass();

            objQuestionClass = glbManagerQuestion.GetCurrentQuestion(out sMessage);
            GetDataScreen(objQuestionClass, out sMessage);

            objQuestionClass = glbManagerQuestion.PreviousQuestion(out sMessage);
            FillScreen(objQuestionClass, out sMessage);
        }

        private void FillScreen(QuestionClass pQuestion, out string sMessage)
        {
            sMessage = string.Empty;
            try
            {
                lbQuestion.Text = pQuestion.Description;

                rb1Text.Text = pQuestion.ListOption[0].Description;
                rb1Text.Checked = pQuestion.ListOption[0].Cheecked;

                rb2Text.Text = pQuestion.ListOption[1].Description;
                rb2Text.Checked = pQuestion.ListOption[1].Cheecked;

                rb3Text.Text = pQuestion.ListOption[2].Description;
                rb3Text.Checked = pQuestion.ListOption[2].Cheecked;

                rb4Text.Text = pQuestion.ListOption[3].Description;
                rb4Text.Checked = pQuestion.ListOption[3].Cheecked;

            }
            catch (Exception ex)
            {
                sMessage = "Error unexpected! Exception[" + ex.Message + "]";
            }
        }
        private void GetDataScreen(QuestionClass pQuestion, out string sMessage)
        {
            sMessage = string.Empty;
            try
            {
                pQuestion.ListOption[0].Cheecked = rb1Text.Checked;
                pQuestion.ListOption[1].Cheecked = rb2Text.Checked;
                pQuestion.ListOption[2].Cheecked = rb3Text.Checked;
                pQuestion.ListOption[3].Cheecked = rb4Text.Checked;
            }
            catch (Exception ex)
            {
                sMessage = "Erro unexpected! Exception[" + ex.Message + "]";
            }
        }

        class ManagerQuestion
        {
            private int iIndexQuestion;
            private int iTotalQuestion;
            public List<QuestionClass> ListQuestion { get; set; }
            public void GenerateQuestion(out string sMessage)
            {
                sMessage = string.Empty;
                try
                {
                    QuestionClass objQuestion = new QuestionClass();
                    objQuestion.Id = 1;
                    objQuestion.Description = "Simple Past";

                    Option objOption1 = new Option();
                    objOption1.Id = 1;
                    objOption1.Description = "be";

                    Option objOption2 = new Option();
                    objOption2.Id = 2;
                    objOption2.Description = "was/were";

                    Option objOption3 = new Option();
                    objOption3.Id = 3;
                    objOption3.Description = "been";

                    objQuestion.ListOption.Add(objOption1);
                    objQuestion.ListOption.Add(objOption2);
                    objQuestion.ListOption.Add(objOption3);

                    this.ListQuestion.Add(objQuestion);
                    iTotalQuestion++;

                    objQuestion.RandomOption(out sMessage);

                    objQuestion = new QuestionClass();
                    objQuestion.Id = 2;
                    objQuestion.Description = "Simple Past";

                    objOption1 = new Option();
                    objOption1.Id = 4;
                    objOption1.Description = "dig";

                    objOption2 = new Option();
                    objOption2.Id = 5;
                    objOption2.Description = "dug";

                    objOption3 = new Option();
                    objOption3.Id = 6;
                    objOption3.Description = "done";

                    objQuestion.ListOption.Add(objOption1);
                    objQuestion.ListOption.Add(objOption2);
                    objQuestion.ListOption.Add(objOption3);

                    objQuestion.RandomOption(out sMessage);

                    this.ListQuestion.Add(objQuestion);
                    iTotalQuestion++;
                }
                catch (Exception ex)
                {
                    sMessage = "Erro unespected [" + ex.Message + "]";
                }
            }
            public ManagerQuestion()
            {
                this.ListQuestion = new List<QuestionClass>();
                iIndexQuestion = 0;
            }
            public QuestionClass NextQuestion(out string sMessage)
            {
                sMessage = string.Empty;
                QuestionClass objQuestion = new QuestionClass();
                try
                {
                    iIndexQuestion++;
                    if (iIndexQuestion < iTotalQuestion)
                    {
                        objQuestion = ListQuestion[iIndexQuestion];
                    }
                    else if( ListQuestion.Count > 0)
                    {
                        iIndexQuestion = 0;
                        objQuestion = ListQuestion[0];
                    }
                }
                catch (Exception ex)
                {
                    sMessage = "Erro unexpected! Exception[" + ex.Message + "]";
                }

                return objQuestion;
            }
            public QuestionClass PreviousQuestion(out string sMessage)
            {
                sMessage = string.Empty;
                QuestionClass objQuestion = new QuestionClass();
                try
                {
                    iIndexQuestion--;
                    if (iIndexQuestion > 0)
                    {
                        objQuestion = ListQuestion[iIndexQuestion];
                    }
                    else if (ListQuestion.Count > 0)
                    {
                        iIndexQuestion = 0;
                        objQuestion = ListQuestion[0];
                    }
                }
                catch (Exception ex)
                {
                    sMessage = "Error unexpected! Message Exception[" + ex.Message + "]";
                }
                return objQuestion;
            }
            public QuestionClass GetCurrentQuestion(out string sMessage)
            {
                sMessage = string.Empty;
                QuestionClass objQuestion = new QuestionClass();
                try
                {
                    objQuestion = ListQuestion[iIndexQuestion];
                }
                catch (Exception ex)
                {
                    sMessage = "Erro unexpected! Exception[" + ex.Message + "]";
                }
                return objQuestion;
            }
        }

        class QuestionClass
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public List<Option> ListOption { get; set; }

            public QuestionClass()
            {
                this.Id = 0;
                this.Description = string.Empty;
                this.ListOption = new List<Option>();
            }

            public void RandomOption(out string sMessage)
            {
                sMessage = string.Empty;
                try
                {
                    Dictionary<int, Option> dcListOptions = new Dictionary<int, Option>();
                    List<int> ListReaded = new List<int>();

                    int iIndex, iCountOption = 0;
                    foreach (Option pOption in this.ListOption)
                    {
                        dcListOptions.Add(iCountOption++, pOption);
                    }

                    Random rdFirst = new Random();
                    this.ListOption = new List<Option>();

                    for (int i = 0; i < iCountOption; i++)
                    {
                        do
                        {
                            iIndex = rdFirst.Next(iCountOption);

                        } while (ListReaded.Contains(iIndex));

                        ListReaded.Add(iIndex);

                        this.ListOption.Add(dcListOptions[iIndex]);
                    }

                }
                catch (Exception ex)
                {
                    sMessage = "Error unespected! Ex[" + ex.Message + "]";
                }
            }
        }

        class Option
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Cheecked { get; set; }

            public Option()
            {
                this.Id = 0;
                this.Description = string.Empty;
                this.Cheecked = false;
            }
        }


    }
}