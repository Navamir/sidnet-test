using NUnit.Framework;


namespace SidnetTest.TestCases
{
    internal class AddNormalAgentAdminRightsTestCase
    {
        LogInAsNormalUser logInAsNormalUserStep;
        LogInAsAdministrator logInAsAdministratorStep;
        AddNonAdminUserAdminRights addNonAdminUserAdminRightsStep;
        LogInAndCheckIfAdminRights logInAndCheckIfAdminRightsStep;

        public void Initiate()
        {
            logInAsNormalUserStep = new LogInAsNormalUser();
            logInAsAdministratorStep = new LogInAsAdministrator();
            addNonAdminUserAdminRightsStep = new AddNonAdminUserAdminRights();
            logInAndCheckIfAdminRightsStep = new LogInAndCheckIfAdminRights();
        }

        [Test]
        public void Test()
        {
            Initiate();

            logInAsNormalUserStep.Run();
            logInAsAdministratorStep.Run();
            addNonAdminUserAdminRightsStep.Run();
            logInAndCheckIfAdminRightsStep.Run();
        }
    }
}
