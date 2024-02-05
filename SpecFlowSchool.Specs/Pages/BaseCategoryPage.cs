namespace SpecFlowSchool.Specs.Pages
{
    internal class BaseCategoryPage : PageBase
    {
        private string clickableDivForSection(string sectionName) => $"//*[text()='{sectionName}']//ancestor::*[contains(@class, 'btn-light')]";
        
        public BaseCategoryPage(PageContext context) : base(context)
        {
        }

        public void SelectSection(string sectionName)
        {
            ClickByXPath(clickableDivForSection(sectionName));
        }
    }
}
