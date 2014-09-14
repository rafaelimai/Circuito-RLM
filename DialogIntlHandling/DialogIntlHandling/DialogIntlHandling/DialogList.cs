using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{
    class DialogList
    {
        private List<Dialog> dialogList;
        private List<Language> avaliableLanguages;
        private List<Issue> issues;
        
        public DialogList()
        {
            dialogList = new List<Dialog>();
            avaliableLanguages = new List<Language>();
            issues = new List<Issue>();
        }

        public Dialog retrieveEntry(int entry)
        {
            Dialog d = null;
            d = dialogList.ElementAt(entry);
            return d;
        }

        public void checkIssues() 
        { 
            
            for (int i = 0; i < dialogList.Count; i++)
            {
                Dialog d = dialogList.ElementAt(i);
                Issue newIssue;
                if (d.needsToBeReviewed)
                {
                    newIssue = new Issue(i, Issue.NEED_TO_BE_REVIEWED, null);
                    issues.Add(newIssue);
                }
                else
                {
                    foreach (Language l in avaliableLanguages)
                    {
                        if (!d.isAvaliableOnLanguage(l))
                        {
                            newIssue = new Issue(i, Issue.MISSING_LANGUAGE, l);
                        }
                    }
                }
            }
        }

        public List<Issue> getIssues()
        {
            return issues;
        }



    }
}
