using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AutoItX3Lib;
using static NUnit.Core.NUnitFramework;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        ////Storing the table of available days
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        //private IWebElement Days { get; set; }

        ////Storing the starttime
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        //private IWebElement StartTime { get; set; }

        ////Click on StartTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        //private IWebElement StartTimeDropDown { get; set; }

        ////Click on EndTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        //private IWebElement EndTimeDropDown { get; set; }

        ////Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[1]")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'ReactTags__tagInputField')])[2]")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

       //

        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button'][contains(.,'Yes')]")]
        private IWebElement clickActionsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//i[contains(@class,'huge plus circle icon padding-25')]")]
        private IWebElement workSamples { get; set; }



        internal void EnterShareSkill()
        {
            //Explicit wait o find the shareskill button element
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Share Skill"), 5);

            //Thread.Sleep(1500);
            ShareSkillButton.Click();
            //Populating with excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            //Enter the Title in textbox 2
            Thread.Sleep(500);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            if (Title.GetAttribute("value") == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))
            {
                Base.test.Log(LogStatus.Pass, "Title is entered and displayed successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Title is not enetered and displayed successfully");
            }
       
            //Enter the Description in textbox 3
            Thread.Sleep(500);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            //Selecting the category
            SelectElement Category = new SelectElement(CategoryDropDown);
            Category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            //Selecting the sub category
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            //Entering the tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + "\n");
            //Clicking the Service type option
            ServiceTypeOptions.Click();
            //Clicking the Location option
            LocationTypeOption.Click();


            //Handling the Date and time
            Thread.Sleep(500);
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            Thread.Sleep(500);
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            Thread.Sleep(500);
            for (int i = 0; i <= 9; i++)
            {
                var checkBox = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[1]/div/input"));
                var dayName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[1]/div/label"));
                var startTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[2]/input"));
                var endTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (2 + i) + "]/div[3]/input"));

                if (GlobalDefinitions.ExcelLib.ReadData(2, "Selectday") == dayName.Text)
                {
                    Thread.Sleep(500);
                    checkBox.Click();
                    Thread.Sleep(500);
                    startTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    Thread.Sleep(500);
                    endTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    break;
                }
            }

             
            



            
            Thread.Sleep(500);
            //Clicking the Skills option
            SkillTradeOption.Click();
            Thread.Sleep(500);     
            //sending the skill exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange") + "\n");


            //Uploading File
            Thread.Sleep(500);
            workSamples.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(3000);
            //autoIt.Send(@"C:\Users\HP\Downloads\marsframework-master\FileToUpload.txt");
            autoIt.Send(Base.FileToUploadPath);
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");


            Thread.Sleep(3000);
            //clicking the Active button
            ActiveOption.Click();
            //Saving the skills
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

        internal void SkillClearoutAddedData()
        {
            //Clearing out the added skills
            Thread.Sleep(500);
            manageListingsLink.Click();
            Thread.Sleep(500);         
            var DescriptionCount = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr")).Count;

            for (int i = 1; i <= DescriptionCount; i++)
            {
                var DescriptionText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                Console.WriteLine(DescriptionText);
                var TitleText = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                Console.WriteLine(TitleText);



                var DescriptionToDelete = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                Console.WriteLine(DescriptionToDelete);
                var TitleToDelete = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Console.WriteLine(TitleToDelete);


                if (DescriptionText == DescriptionToDelete && TitleText == TitleToDelete)
                {
                    Thread.Sleep(500);
                    var DeleteButton = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i"));
                    DeleteButton.Click();
                    Thread.Sleep(500);
                    clickActionsButton.Click();
                    break;

                }
                else
                {
                    Console.WriteLine("Skill is not Present");
                }                
            }

            Thread.Sleep(3000);
            var DescriptionAssert2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")).Text;
            NUnit.Framework.Assert.That(DescriptionAssert2, Is.Not.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
        }
    }
}
