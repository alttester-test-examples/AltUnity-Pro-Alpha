using NUnit.Framework;
using Altom.AltUnityDriver;

public class TanksTests
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
        altUnityDriver.LoadScene("_Complete-Game");
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestTanksArePresent()
    {
	    altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
    }

    [Test]
    public void TestTanksStartWithFullLife()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        var tankHealth=altUnityDriver.WaitForObject(By.PATH,"//CompleteTank(Clone)/Canvas/HealthSlider/Fill Area/Fill");
        var slider=tankHealth.GetComponentProperty("UnityEngine.UI.Image", "fillAmount");
        Assert.AreEqual(slider,"1.0");

    }

    [Test]
    public void TestPlayer1Moves()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.FindObject(By.NAME,"SpawnPoint1");
        var initialPosition=tank.getScreenPosition();
        altUnityDriver.KeyDown(AltUnityKeyCode.UpArrow,1);
        altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        var tankHealth=altUnityDriver.WaitForObject(By.PATH,"//CompleteTank(Clone)/Canvas/HealthSlider/Fill Area/Fill");
        var slider=tankHealth.GetComponentProperty("UnityEngine.UI.Image", "fillAmount");
        altUnityDriver.KeyUp(AltUnityKeyCode.UpArrow);
        var finalPosition=tank.getScreenPosition();
        Assert.AreNotEqual(initialPosition,finalPosition);
    }
    [Test]
    public void TestPlayer1Attacks()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.FindObject(By.NAME,"SpawnPoint1");
        altUnityDriver.PressKeyAndWait(AltUnityKeyCode.W,2);
        altUnityDriver.KeyDown(AltUnityKeyCode.Space,2);
        altUnityDriver.WaitForObject(By.NAME,"CompleteShellExplosion");

    }
      [Test]
    public void TestPlayer2Attacks()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.FindObject(By.NAME,"SpawnPoint2");
        altUnityDriver.KeyDown(AltUnityKeyCode.KeypadEnter,2);
        altUnityDriver.WaitForObject(By.NAME,"CompleteShellExplosion");

    }

    [Test]
    public void TestPlayerMovesWhenAttacked()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.FindObject(By.NAME,"SpawnPoint1");
        var initialPosition=tank.getScreenPosition();
        altUnityDriver.KeyDown(AltUnityKeyCode.LeftArrow,1);
        altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        altUnityDriver.KeyUp(AltUnityKeyCode.LeftArrow);
        altUnityDriver.KeyDown(AltUnityKeyCode.UpArrow,1);
        var tankHealth=altUnityDriver.WaitForObject(By.PATH,"//CompleteTank(Clone)/Canvas/HealthSlider/Fill Area/Fill");
        var slider=tankHealth.GetComponentProperty("UnityEngine.UI.Image", "fillAmount");
        altUnityDriver.KeyUp(AltUnityKeyCode.UpArrow);
        var finalPosition=tank.getScreenPosition();
        Assert.AreNotEqual(initialPosition,finalPosition);
    }


}