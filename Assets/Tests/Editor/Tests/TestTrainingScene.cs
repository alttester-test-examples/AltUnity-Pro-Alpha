using NUnit.Framework;
using Altom.AltUnityDriver;

public class TestTrainingScene
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
    public void TestStartGame()
    {
        altUnityDriver.LoadScene("LobbyScene");
        var createButton=altUnityDriver.FindObject(By.PATH,"//Buttons/SinglePlayer");
        createButton.Tap();
        altUnityDriver.WaitForObject(By.NAME,"SinglePlayerPanel");
        altUnityDriver.FindObject(By.PATH,"//SinglePlayerPanel//AcceptButton/StartGame").Tap();
        altUnityDriver.WaitForObject(By.NAME,"SinglePlayerStartGameModal(Clone)");
        altUnityDriver.FindObject(By.PATH,"//SinglePlayerStartGameModal(Clone)//Start Button").Tap();
    }
    [Test]
    public void TestFireBombs()
    {
        altUnityDriver.LoadScene("Mission1_MoveAndShoot");
        altUnityDriver.FindObject(By.PATH,"//CompleteTank(Clone)//Panzer").Tap(4);
        altUnityDriver.WaitForObject(By.NAME,"MuzzleFlash(Clone)");
    }
    [Test]
    public void TestFightEnemy()
    {
        altUnityDriver.LoadScene("Mission1_MoveAndShoot");
        altUnityDriver.PressKey(AltUnityKeyCode.W, 1,0.5f);

        // altUnityDriver.FindObject(By.PATH,"//CompleteTank(Clone)//Panzer").Tap();
    }

}