using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace VoiceApplicaion
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();

            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//grammar.text");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngine_SpeechRecongnized);
            speech.SelectVoiceByHints(VoiceGender.Male);
        }

        private void recEngine_SpeechRecongnized(object sender, SpeechRecognizedEventArgs e)
        {
            String result = e.Result.Text;

            if (result == "Hello")
            {
                result = "Merhaba BEnim Adim Mete";

            }

            else if (result == "How are you")
            {
                result = "Sag ol Sen Nasilsin";

            }

            else if (result == "how old are you")
            {
                result = "1 yasindayim";

            }

            else if (result == "where do you live")
            {
                result = "Copmuter";

            }


            else if (result == "open Google")
            {
                result = "Googleyi acamiyorim";

            }


            speech.SpeakAsync(result);
            lblKONUS.Text = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
