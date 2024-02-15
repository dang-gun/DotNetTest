namespace T5577_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //https://ko.aliexpress.com/item/1005003319361688.html?src=google&src=google&albch=shopping&acnt=631-313-3945&slnk=&plac=&mtctp=&albbt=Google_7_shopping&albagn=888888&isSmbActive=false&isSmbAutoCall=false&needSmbHouyi=false&albcp=19147525093&albag=&trgt=&crea=ko1005003319361688&netw=x&device=c&albpg=&albpd=ko1005003319361688&gclid=CjwKCAiAq4KuBhA6EiwArMAw1LJah9K-BoBfYBH250IB6QQ5Z51OMrOAX7XgG6m7F0q0FnUvTAk42xoCxdIQAvD_BwE&gclsrc=aw.ds&aff_fcid=1ce68342f2c54504be2fb5e1b9383b3b-1707126000298-03984-UneMJZVf&aff_fsk=UneMJZVf&aff_platform=aaf&sk=UneMJZVf&aff_trace_key=1ce68342f2c54504be2fb5e1b9383b3b-1707126000298-03984-UneMJZVf&terminal_id=7ae037b3471e46e68cae50923fe8ba05&afSmartRedirect=y

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();

            byte[] command = new byte[] { 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; // 이 부분에 T5577 카드에 쓰고자 하는 데이터를 넣으세요.
            port.Write(command, 0, command.Length);

            port.Close();
        }
    }
}
