using MarsFramework.Global;
using MarsFramework.Pages;
using MongoDB.Driver.Core.Connections;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.Configuration;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Test1SahreSkillsAdd()
            {
                test = extent.StartTest("Add Share Skills Deatails");
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
                //test.Log(LogStatus.Info, "Starting the Add Skill Test");
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();
                bool actual = shareSkill.Verify();
                if (actual)
                {
                    Base.test.Log(LogStatus.Pass, "Skills Added Pass");
                }
                else
                {
                    Base.test.Log(LogStatus.Pass, "Skills not added");
                }

                // Clearing out the added data
                shareSkill.SkillClearoutAddedData();

                //ManageListings manageListings = new ManageListings();
                //manageListings.EditManageListings();

                //ManageListings manageListings2 = new ManageListings();
                //manageListings2.DeleteManageListings();

            }

            [Test]
            public void Test2ManageSkillsEdit()
            {
                test = extent.StartTest("Edit Skills Deatails");
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                ManageListings manageListings = new ManageListings();
                manageListings.EditManageListings();
                bool actual = manageListings.Verify();
                if (actual)
                {
                    Base.test.Log(LogStatus.Pass, "Manage Skills Edit Pass");
                }
                else
                {
                    Base.test.Log(LogStatus.Pass, "Manage Skills Edit added");
                }
            }

            [Test]
            public void Test3ManageSkillsDelete()
            {
                test = extent.StartTest("Delete Skills Deatails");
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteManageListings();
                bool actual = manageListings.Verify();
                if (!actual)
                {
                    Base.test.Log(LogStatus.Pass, "Manage Skills delete successfully");
                }
                else
                {
                    Base.test.Log(LogStatus.Pass, "Manage Skills not deleted");
                }
            }


        }
    }
}