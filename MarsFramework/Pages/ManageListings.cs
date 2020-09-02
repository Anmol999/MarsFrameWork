using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AutoItX3Lib;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[8]/div/button[3]/i
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[3]/td[8]/div/button[3]/i
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button'][contains(.,'Yes')]")]
        private IWebElement clickActionsButton { get; set; }





        //Newly added elements for the edit page which Acts as add
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'title')]")]
        private IWebElement Title { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[contains(@name,'description')]")]
        private IWebElement Description { get; set; }
        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'categoryId')]")]
        private IWebElement CategoryDropDown { get; set; }
        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'subcategoryId')]")]
        private IWebElement SubCategoryDropDown { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'ReactTags__tagInputField')])[1]")]
        private IWebElement Tags { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'serviceType')])[2]")]
        private IWebElement ServiceTypeOptions { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'locationType')])[1]")]
        private IWebElement LocationTypeOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'startDate')]")]
        private IWebElement StartDateDropDown { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'endDate')]")]
        private IWebElement EndDateDropDown { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[1]")]
        private IWebElement SkillTradeOptionSkillExchange { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[2]")]
        private IWebElement SkillTradeOptionCredit { get; set; }
       
        [FindsBy(How = How.XPath, Using = "(//input[@aria-label='Add new tag'])[2]")]
        private IWebElement SkillExchangeTags { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'isActive')])[1]")]
        private IWebElement ActiveOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
        [FindsBy(How = How.XPath, Using = "//i[contains(@class,'huge plus circle icon padding-25')]")]
        private IWebElement workSamples { get; set; }




        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }

        internal void EditManageListings()
        {
            Thread.Sleep(500);
            //Clicking the manage listing button
            manageListingsLink.Click();
            Thread.Sleep(500);
            //Clicking edit button(edit is acting as adding option only)
            edit.Click();
            Thread.Sleep(500);
            //Populating with excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
            //Enetering Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            //Entering Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            //Selecting Category
            SelectElement Category = new SelectElement(CategoryDropDown);
            Category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            //Slecting Subcategory
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            //Entering the Tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + "\n");
            //Clicking the Service type
            ServiceTypeOptions.Click();
            //Clicking the Type option
            LocationTypeOption.Click();

            //Handling the Date and time
            Thread.Sleep(500);
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));//Sending start date data
            Thread.Sleep(500);
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));//sending end date data
            Thread.Sleep(1500);
            //Looping for the targeted day, timings and corresponding check box
            for (int i = 0; i <= 9; i++)
            {
                var checkBox = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[1]/div/input"));
                var dayName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[1]/div/label"));
                var startTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[2]/input"));
                var endTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[3]/input"));

                if (GlobalDefinitions.ExcelLib.ReadData(2, "Selectday") == dayName.Text)
                {
                    Thread.Sleep(500);
                    //Clicking checkbox
                    checkBox.Click();
                    Thread.Sleep(500);
                    //Entering particular start timing in targeted day
                    startTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    Thread.Sleep(500);
                    //Entering particular End timings in targeted day
                    endTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    break;
                }

            }

            Thread.Sleep(500);
            //Clicking Skills Exchange
            SkillTradeOptionSkillExchange.Click();
            Thread.Sleep(500);
            //Enetering Skill Exchnge Tag
            SkillExchangeTags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange") + "\n");
            Thread.Sleep(500);
            //Clicking Credit 
            SkillTradeOptionCredit.Click();
            Thread.Sleep(500);
            //Entering Credit
            CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));

            //Uploading File
            Thread.Sleep(500);
            workSamples.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(3000);
            autoIt.Send(Base.FileToUploadPath);
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");


            //Clicking Active option
            ActiveOption.Click();
            //Saving the new/ updated Manage skills
            Save.Click();


            //Asserts
            Thread.Sleep(3000);
            var DescriptionAssert = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")).Text;
            NUnit.Framework.Assert.That(DescriptionAssert, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
        }

        // Verify share skills   
        internal bool Verify()
        {
            //Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(1000);
            int DescriptionCountVerify = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr")).Count;
            bool recordFound = false;
            for (int i = 1; i <= DescriptionCountVerify; i++)
            {
                var DescriptionTextVerify = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;

                if (DescriptionTextVerify == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }

        internal void DeleteManageListings()
        {
            Thread.Sleep(500);
            //Clicking the Manage listing button again
            manageListingsLink.Click();
            Thread.Sleep(500);   
            //Populating with data from excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");   
            //Counting nuber of enteries in body of the table
            var DescriptionCount = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr")).Count;
           
            for (int i = 1; i <= DescriptionCount; i++)
            {           //Getting the text of the added description    
                var DescriptionText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                Console.WriteLine(DescriptionText);
                //Getting the text of the added Title
                var TitleText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                Console.WriteLine(TitleText);
                      

                //Getting the data of the Description we awere suppose to enter in edit part
                var DescriptionToDelete = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                Console.WriteLine(DescriptionToDelete);
                //Getting the data of the Title we awere suppose to enter in edit part
                var TitleToDelete = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Console.WriteLine(TitleToDelete);                  
               // Doing if validation to compare title added with title that was required to be added and similar for the description
                if (DescriptionText == DescriptionToDelete && TitleText == TitleToDelete)
                {                   
                    Thread.Sleep(500);
                    // Selecting the delete button in front of the selected element
                    var DeleteButton = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i"));
                    //Clicking the Delete Button
                    DeleteButton.Click();
                    Thread.Sleep(500);    
                    //Click the confirmation button with yes or no option to delete
                    clickActionsButton.Click();                    
                    break;
                }
                else
                {
                    Console.WriteLine("Skill is not Present");
                }
            }
            //Asserts
            Thread.Sleep(3000);
            var DescriptionAssert2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")).Text;
            NUnit.Framework.Assert.That(DescriptionAssert2, Is.Not.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
        }
    }

    
}
