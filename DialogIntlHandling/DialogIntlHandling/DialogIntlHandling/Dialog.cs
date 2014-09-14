using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogIntlHandling
{

    /*
     * The class Dialog abstracts a real-life dialog, that can be translated to various languages.
     * WARNING: Languages here are represented through a combination of ISO 3166-1 (countries) and ISO 639-1 (languages) standards.
     * e.g, pt-br (Brazilian Portuguese) is composed by a combination of the above standards. "pt" is the ISO 639-1 code for portuguese, and "br" is the ISO 3166-1 code for Brazil.
     * This notation is adopted when the language presents derivations for different countries. Using the example above, pt-pt represent the Portuguese Portuguese.
     * Mostly, languages don't demand the additional country specification.In this case, the country code is disregarded (i.e, only the ISO 639-1 language code is used).
     * 
     */
    public class Dialog
    {

        /*
         * List of the translations avaliable for this dialog. The first string represents the language (through the use of ISO 3166-1 and ISO 639-1 standards),
         *  and the second string the translation itself.
         */
        private Dictionary<Language, String> translationList;

        //The default language (the original language used to write the dialog), also adopting the above standard.
        private string defaultLanguage {get;set;}


        //List with the languages used to translate the dialog.
        private List<Language> avaliableLanguages;

        //Flag that indicates that this dialog needs to be reviewed.
        public Boolean needsToBeReviewed { get; set; }

        //Default constructor.
        public Dialog()
        {
            translationList = new Dictionary<Language, string>();
            avaliableLanguages = new List<Language>();
        }

        //Constructor overload, if setting the defaultLanguage is required.
        public Dialog(string defaultLanguage)
        {
            translationList = new Dictionary<Language, string>();
            avaliableLanguages = new List<Language>();
            this.defaultLanguage = defaultLanguage;
        }

        //Add a new translation to the dialog, given a standardized language and the new translation.
        public void addTranslation(Language language, String translation)
        {
            translationList.Add(language, translation);
        }

        //Retrieves a translation of the dialog, given an input language.
        //Returns "Translations of this dialog on the given language were not found." if the required translation is not found.
        public string getTranslation(Language language)
        {
            String value = "Translations of this dialog on the given language were not found.";
            translationList.TryGetValue(language, out value);
            return value;
        }

        //Check if there is a translation of the dialog in the given language.
        //Return values indicate the answer.
        public bool isAvaliableOnLanguage(Language language)
        {
            String value = null;
            translationList.TryGetValue(language, out value);

            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //R
        public List<Language> getAvaliableLanguages()
        {
            return avaliableLanguages;
        }
      
                
    }
}
