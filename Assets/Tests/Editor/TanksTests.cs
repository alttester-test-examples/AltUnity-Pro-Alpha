using NUnit.Framework;
using Altom.AltUnityDriver;

public class TanksTests
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        string portStr = System.Environment.GetEnvironmentVariable("PROXY_PORT");
        int port = 13000;
        if (!string.IsNullOrEmpty(portStr)) port = int.Parse(portStr);
        altUnityDriver = new AltUnityDriver(port: port, enableLogging: true);
        altUnityDriver.LoadScene("_Complete-Game");
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestGameStart()
    {
	    altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
    }

    [Test]
    public void TestPlayerStartsWithFullLife()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        var health=tank.GetComponentProperty("Complete.TankHealth","m_StartingHealth");
        Assert.AreEqual(health,"100.0");

    }
    [Test]
    public void TestPlayer1Dies()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank= altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        object[] parameters = new object[] { };
        tank.CallComponentMethod<string>("Complete.TankHealth","OnDeath",parameters);
        var isDead=tank.GetComponentProperty("Complete.TankHealth","m_Dead");
        Assert.AreEqual(isDead, "true");
    }
    [Test]
    public void TestPlayerTakeDamage()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank= altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        object[] parameters = new object[1] {0.5f};
        tank.CallComponentMethod<string>("Complete.TankHealth","TakeDamage",parameters);
        var health=tank.GetComponentProperty("Complete.TankHealth","m_CurrentHealth");
        Assert.AreEqual(health,"99.5");
    }
   
   
    [Test]
    public void TestPlayer1Attacks()
    {
        altUnityDriver.WaitForObject(By.NAME,"SpawnPoint1");
    	altUnityDriver.WaitForObject(By.NAME,"SpawnPoint2");
        var tank=altUnityDriver.WaitForObject(By.NAME,"CompleteTank(Clone)");
        object[] parameters = new object[] { };
        tank.CallComponentMethod<string>("Complete.TankShooting","Fire",parameters);
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

   


}