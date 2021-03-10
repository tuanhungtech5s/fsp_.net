using FunSupply.Common;
using FunSupply.DataTranfers;
using FunSupply.Enums;
using FunSupply.Log;
using FunSupply.Workers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunSupply
{
    public partial class Form1 : Form
    {
        IWebDriver[] profileDrivers = new IWebDriver[2];
        SimpleLog logger;
        Worker worker;
        public Form1()
        {
            InitializeComponent();
            Environment.SetEnvironmentVariable("webdriver.chrome.driver", Application.StartupPath + "chromedriver.exe");
            this.logger = new FileLog();
        }
        


        private void btnStart_Click(object sender, EventArgs e)
        {


            var typeStart = validateProfile();

            if (typeStart == TypeStart.PROFILE1 || typeStart == TypeStart.BOTH)
            {
                startSeleliumProfile1(txtProfileDir1.Text, txtProfile1.Text);
            }
            if (typeStart == TypeStart.PROFILE2 || typeStart == TypeStart.BOTH)
            {
                startSeleliumProfile2(txtProfileDir2.Text, txtProfile2.Text);
            }

        }
        public void onReceiveAuction(List<AuctionObject> auctions)
        {
            if (auctions == null || auctions.Count==0) return;
            var auction = auctions[0];
            var driverindex = this.getIdleWebDriver();
            if (driverindex >= 0)
            {
                var result = bidProduct(driverindex, auction);
                SendResponse res = new SendResponse();
                res.start(result);
            }
        }
        private int getIdleWebDriver()
        {
            if (!AppConfig.STATUS_DRIVERS[0])
            {
                AppConfig.STATUS_DRIVERS[0] = true;
                return 0;
            }
            if (!AppConfig.STATUS_DRIVERS[1])
            {
                AppConfig.STATUS_DRIVERS[1] = true;
                return 1;
            }
            return -1;
        }
        private void startSeleliumProfile1(string dir,string profile)
        {
            AppConfig.getLog().Log("Chrome Driver 1 starting...");
            this.profileDrivers[0] = this.startSelelium(dir, profile);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.profileDrivers[0].Manage().Window.Size = new Size(width / 2, height);
            this.profileDrivers[0].Manage().Window.Position = new Point(0, 0);
        }
        private void startSeleliumProfile2(string dir, string profile)
        {
            AppConfig.getLog().Log("Chrome Driver 2 starting...");
            this.profileDrivers[1] = this.startSelelium(dir, profile);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.profileDrivers[1].Manage().Window.Size = new Size(width / 2, height);
            this.profileDrivers[1].Manage().Window.Position = new Point(width/2, 0);
        }
        private IWebDriver startSelelium(string dir, string profile)
        {
            ChromeOptions chOption = new ChromeOptions();
            chOption.AddArguments(new string[]
            {
            "--start-maximized"
            });
            chOption.AddArguments(new string[]
            {
            "--disable-web-security"
            });
            chOption.AddArguments(new string[]
            {
            "--allow-running-insecure-content"
            });
            chOption.AddArguments(new string[]
            {
            "--user-data-dir=" + dir
            });
            chOption.AddArguments(new string[]
            {
            "profile-directory=" + profile
            });
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(service, chOption);
            return driver;
        }
        private Enums.TypeStart validateProfile()
        {
            bool profile1 = txtProfileDir1.Text.Trim().Length > 0 && txtProfile1.Text.Trim().Length > 0;
            bool profile2 = txtProfileDir2.Text.Trim().Length > 0 && txtProfile2.Text.Trim().Length > 0;
            if(!profile1 && !profile2)
            {
                MessageBox.Show("Vui lòng chọn Profile Chrome trước khi chạy chương trình!");
                return TypeStart.NONE;
            }
            else
            {
                if (profile1 && profile2)
                {
                    DialogResult result =  MessageBox.Show("Bạn muốn chạy chương trình với cả Profile 1 và Profile 2", "Thông báo", MessageBoxButtons.OKCancel);
                    return result == DialogResult.OK ? TypeStart.BOTH : TypeStart.NONE;
                }
                else
                {
                    if (profile1)
                    {
                        DialogResult result = MessageBox.Show("Bạn muốn chạy chương trình với Profile 1","Thông báo",MessageBoxButtons.OKCancel);
                        return result == DialogResult.OK ? TypeStart.PROFILE1 : TypeStart.NONE;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn muốn chạy chương trình với Profile 2", "Thông báo", MessageBoxButtons.OKCancel);
                        return result == DialogResult.OK ? TypeStart.PROFILE2 : TypeStart.NONE;
                    }
                }
            }
        }
        private AuctionResult bidProduct(int driverindex, AuctionObject auction)
        {
            AuctionResult result = new AuctionResult();
            result.Id = auction.Id;
            result.Code = "100";
            try
            {
                AppConfig.getLog().Log(string.Format("Navigate: Auction ID {0} Link {1} Price {2}", auction.Id, auction.Link, auction.Price));
                var driver = this.profileDrivers[driverindex];
                if (driver == null)
                {
                    result.Text = "Lỗi driver null!";
                    result.Url = "";
                    return result;
                }
                result.Url = driver.Url;
                driver.Navigate().GoToUrl(auction.Link);
                WebDriverWait _wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                _wait.Until(d => d.FindElement(By.XPath("//a[contains(@class,'Button--bid')]")));
                var modal = driver.FindElement(By.XPath("//div[contains(@class,'prMdl ')]"));
                if (modal != null && modal.Displayed)
                {
                    var closeModal = driver.FindElement(By.XPath("//a[contains(@class,'prMdl__close')]"));
                    closeModal.Click();
                }
                var buttonBid = driver.FindElement(By.XPath("//a[contains(@class,'Button--bid')]"));
                AppConfig.getLog().Log(auction.Link + " Found Button Bid & click!");
                if (buttonBid != null)
                {
                    buttonBid.Click();
                    Thread.Sleep(500);
                }

                var inputPriceBid = driver.FindElement(By.XPath("//input[@name='Bid']"));
                AppConfig.getLog().Log(auction.Link + " Found Input Price");
                if (inputPriceBid != null)
                {
                    AppConfig.getLog().Log(auction.Link + " Insert Server Price " + auction.Price);
                    inputPriceBid.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    Thread.Sleep(2 * 1000);
                    inputPriceBid.SendKeys(auction.Price);
                    Thread.Sleep(500);
                }

                var formBid = driver.FindElement(By.XPath("//form[@action='https://auctions.yahoo.co.jp/jp/show/bid_preview']"));
                AppConfig.getLog().Log(auction.Link + " Found Form Submit Bid");
                if (formBid != null)
                {
                    formBid.Submit();
                    AppConfig.getLog().Log(auction.Link + " Submit form bid");
                    Thread.Sleep(500);
                }
                _wait.Until(d => d.FindElement(By.XPath("//button[contains(@class,'SubmitBox__button--bid')]")));
                var buttonAgreeBid = driver.FindElement(By.XPath("//button[contains(@class,'SubmitBox__button--bid')]"));
                AppConfig.getLog().Log(auction.Link + " Found Button Agree Bid");
                if (buttonAgreeBid != null)
                {
                    AppConfig.getLog().Log(auction.Link + " Click Button Agree");
                    buttonAgreeBid.Click();
                    Thread.Sleep(500);
                }
                var NgAttentions = driver.FindElements(By.XPath("//div[@class='NgAttention']"));
                
                if (NgAttentions.Count>0)
                {
                    var NgAttention = NgAttentions[0];
                    result.Text = NgAttention.Text;
                    result.Url = driver.Url;
                }
                else
                {
                    var modAlertBoxs = driver.FindElements(By.XPath("//div[@id='modAlertBox']"));
                    if (modAlertBoxs.Count>0)
                    {
                        var modAlertBox = modAlertBoxs[0];
                        result.Text = modAlertBox.Text;
                        result.Url = driver.Url;
                        result.Code = "200";

                    }
                }
            }
            catch (Exception ex)
            {
                AppConfig.getLog().Log(auction.Link + "Error "+ex.Message);
                result.Text = "Lỗi: " + ex.Message;
            }
            finally
            {
                AppConfig.STATUS_DRIVERS[driverindex] = false;
            }
            return result;
            
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] tmp = fbd.SelectedPath.Split('\\');
                    string profile = tmp[tmp.Length - 1];
                    string[] dir = tmp.Where((val, idx) => idx != tmp.Length-1).ToArray();
                    var directory = string.Join("\\", dir);
                    txtProfile1.Text = profile;
                    txtProfileDir1.Text = directory;

                }
            }
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            AppConfig.getLog().Log("Worker Clicked!");
            if (!AppConfig.ACCEPT_WORKER)
            {
                AppConfig.ACCEPT_WORKER = true;
                worker = new Worker();
                worker.onComplete = this.onReceiveAuction;
                worker.start();
                btnWorker.Text = "Stop Worker";
            }
            else
            {
                AppConfig.ACCEPT_WORKER = false;
                btnWorker.Text = "Start Worker";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in this.profileDrivers)
            {
                if (item != null)
                {
                    item.Close();
                    item.Quit();
                }
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] tmp = fbd.SelectedPath.Split('\\');
                    string profile = tmp[tmp.Length - 1];
                    string[] dir = tmp.Where((val, idx) => idx != tmp.Length - 1).ToArray();
                    var directory = string.Join("\\", dir);
                    txtProfile1.Text = profile;
                    txtProfileDir1.Text = directory;

                }
            }
        }
    }
}
