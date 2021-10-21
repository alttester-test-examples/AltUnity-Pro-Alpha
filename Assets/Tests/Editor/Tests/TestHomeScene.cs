using NUnit.Framework;
using Altom.AltUnityDriver;

public class TestHomePage
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestCustomizeTank()
    {
        altUnityDriver.LoadScene("LobbyScene");
        var customizeButton=altUnityDriver.FindObject(By.NAME,"CUSTOMIZE");
        customizeButton.Tap();
        altUnityDriver.WaitForObject(By.NAME, "Customization");
        var tankName=altUnityDriver.FindObject(By.NAME,"TankName").GetText();
        Assert.AreEqual(tankName,"PANZER");

    }
    
    [Test]
    public void TestShowSettings()
    {
        altUnityDriver.LoadScene("LobbyScene");
        altUnityDriver.WaitForObjectNotBePresent(By.NAME,"SettingsModal");
        var settingsButton=altUnityDriver.FindObject(By.PATH,"//Buttons/Settings");
        settingsButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"SettingsModal");
    }
    [Test]
    public void TestShowCredits()
    {
        altUnityDriver.LoadScene("LobbyScene");
        altUnityDriver.WaitForObjectNotBePresent(By.NAME,"CreditsModal");
        var settingsButton=altUnityDriver.FindObject(By.PATH,"//Buttons/Credits");
        settingsButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"CreditsModal");
    }

}