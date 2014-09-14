using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{

    /*
     * The class DialogList represents the abstraction of a dialog list. //Circular definitions FTW
     * 
     * Aside from being a list itself, it implements a issue-checking method, that is able to check problems in the listed dialogs.
     */
    class DialogList
    {
        private List<Dialog> dialogList;
        //List the languages that the dialogs in this DialogList should have translations avaliable.
        private List<Language> avaliableLanguages;
        //List found issues while running the checkIssues method.
        private List<Issue> issues;
        
        public DialogList()
        {
            dialogList = new List<Dialog>();
            avaliableLanguages = new List<Language>();
            issues = new List<Issue>();
        }

        /*
         * Return a Dialog, given an index number.
         * Returns null if there is nothing at the given index.
         */
        public Dialog retrieveEntry(int entry)
        {
            Dialog d = null;
            d = dialogList.ElementAt(entry);
            return d;
        }


        /*
         * Check the dialogs listed, seeking for:
         * 1-Dialogs that need to be reviewed
         * 2-Dialogs that don't have one or more translations for the languages listed in avaliableLanguages.
         * 
         */
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

        /*
         * Return the issue list.
         */
        public List<Issue> getIssues()
        {
            return issues;
        }



    }
}
