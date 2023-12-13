using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

[TestClass]
public class SidebarTests
{
    private IWebDriver _driver;
    private WebDriverWait wait;


    [TestInitialize]
    public void TestInitialize()
    {
        _driver = new ChromeDriver();
        wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        _driver.Navigate().GoToUrl("https://daviddunne165.github.io/EAD-CA3-MatchScore/");
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _driver.Quit();
    }

    [TestMethod]
    public void Sidebar_Loads_Correctly()
    {
        var sidebarElement =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("sidebar")));
        Assert.IsNotNull(sidebarElement);
    }
    
    [TestMethod]
    public void Favourites_Header_Loads_Correctly()
    {
        var favouritesHeader = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("favourites-header")));
        Assert.IsNotNull(favouritesHeader);
    }

    [TestMethod]
    public void League_Selection_Loads_Correctly()
    {
        var countryItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("country-item")));
        countryItem.Click();

        var leagueItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("league-item")));
        leagueItem.Click();

        var leagueInfo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("league-info")));

        Thread.Sleep(3000);
        Assert.IsTrue(leagueInfo.Displayed);
    }
}

[TestClass] 
public class ContentTests {

    private IWebDriver _driver;
    private WebDriverWait wait;


    [TestInitialize]
    public void TestInitialize()
    {
        _driver = new ChromeDriver();
        wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        _driver.Navigate().GoToUrl("https://daviddunne165.github.io/EAD-CA3-MatchScore/");
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _driver.Quit();
    }

        [TestMethod]
    public void Toggle_Match_Details_Displays_Details()
    {
        var countryItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("country-item")));
        countryItem.Click();

        var leagueItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("league-item")));
        leagueItem.Click();

        var matchRow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("tr[class*='selected-match']"))); 
        matchRow.Click();

        var matchDetails = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("match-details")));
        Assert.IsTrue(matchDetails.Displayed);
    }


    [TestMethod]
    public void Toggle_Standings_Displays_Standings()
    {
        var countryItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("country-item")));
        countryItem.Click();

        var leagueItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("league-item")));
        leagueItem.Click();

        var toggleStandingsButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("toggle-bar")));
        toggleStandingsButton.Click();

        var standingsTable = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("table")));

        Thread.Sleep(3000);
        Assert.IsTrue(standingsTable.Displayed);
    } 
}

[TestClass]
    public class FavoriteClubTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://daviddunne165.github.io/EAD-CA3-MatchScore/");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void Add_Club_To_Favorites()
        {
            var countryItem = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.country-item")));
            countryItem.Click();

            var leagueItem = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.league-item")));
            leagueItem.Click();

            var favouriteButtonIconBefore = _driver.FindElement(By.CssSelector("button.favourite-button i")).GetAttribute("class");

            var favouriteButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.favourite-button")));
            favouriteButton.Click();

            var favouriteButtonIconAfter = _driver.FindElement(By.CssSelector("button.favourite-button i")).GetAttribute("class");

            Thread.Sleep(3000);
            Assert.AreNotEqual(favouriteButtonIconBefore, favouriteButtonIconAfter);
            Assert.IsTrue(favouriteButtonIconAfter.Contains("fas fa-star"));
        }

        [TestMethod]
        public void Add_Club_And_View_Fixtures_In_Favorites()
        {
            var favouriteButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.favourite-button")));
            favouriteButton.Click();

            var favouritesTab = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("favourites-header")));
            favouritesTab.Click();

            var favouriteFixtures = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("matches-table")));
            Assert.IsTrue(favouriteFixtures.Displayed);
        }
    }