using MarsFramework.Pages;
using NUnit.Framework;

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
                
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();


                ManageListings manageListings = new ManageListings();
                manageListings.EditManageListings();

                ManageListings manageListings2 = new ManageListings();
                manageListings2.DeleteManageListings();

            }

          
        }
    }
}