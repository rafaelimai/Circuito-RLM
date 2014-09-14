using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{
    class Issue
    {

        public const int NEED_TO_BE_REVIEWED = 1;
        public const int MISSING_LANGUAGE = 2;

        private Language language;
        private int dialogIndex;
        private int type;

        public Issue(int dialogIndex,int type,Language language)
        {
            this.language = language;
            this.dialogIndex = dialogIndex;
            this.type = type;
        }

        public int getType()
        {
            return type;
        }

        public int getDialogIndex()
        {
            return dialogIndex;
        }

        public Language getLanguage()
        {
            return language;
        }
    }
}
