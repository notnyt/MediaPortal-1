using System;
using System.Text;

namespace MediaPortal.TVGuideScheduler
{
	public class Grabber
	{
		string m_strGrabberName="";
		string m_strConfigFile="";
		string m_strOutput="";
		int m_intDays;
		string m_strOptions="";
		int m_intOffset;
		int m_intGuidedays;


		public Grabber(string xmltvGrabberName)
		{
			m_strGrabberName = xmltvGrabberName;
			SetDefaults(m_strGrabberName);
			GetSettings();
		}

		public string GrabberName
		{
			get { return m_strGrabberName;}
		}
		public string ConfigFile
		{
			get { return m_strConfigFile;}
			set { m_strConfigFile=value;}
		}
		public string Output
		{
			get { return m_strOutput;}
			set { m_strOutput=value;}
		}
		public int Days
		{
			get { return m_intDays;}
			set { m_intDays=value;}
		}
		public int Offset
		{
			get { return m_intOffset;}
			set { m_intOffset=value;}
		}
		public string Options
		{
			get { return m_strOptions;}
			set { m_strOptions=value;}
		}
		public int GuideDays
		{
			get { return m_intGuidedays;}
			set { m_intGuidedays=value;}
		}

		private void SetDefaults(string Grabber)
		{
			switch (Grabber)
			{
				case "tv_grab_de_tvtoday":
					//    tv_grab_de_tvtoday [--config-file FILE] --configure
					//    tv_grab_de_tvtoday [--config-file FILE] [--output FILE] [--days N] [--offset N] [--quiet] [--slow] [--nosqueezeout]
					//    tv_grab_de_tvtoday --list-channels
					m_strConfigFile = "tv_grab_de_tvtoday.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_dk":
					//    tv_grab_dk [--config-file FILE] --configure
					//    tv_grab_dk [--config-file FILE] [--output FILE] [--days N] [--offset N] [--quiet]
					m_strConfigFile = "tv_grab_dk.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_es":
					m_strConfigFile = "tv_grab_es.conf";
					m_intDays = 3;
					m_intOffset = 0;
					break;
				case "tv_grab_es_digital":
					m_strConfigFile = "tv_grab_es_digital.conf";
					m_intDays = 3;
					m_intOffset = 0;
					break;
				case "tv_grab_fi":
					m_strConfigFile = "tv_grab_fi.conf";
					m_intDays = 10;
					m_intOffset = 0;
					break;
				case "tv_grab_fr":
					//    tv_grab_fr --configure [--config-file FILE] To grab
					//    tv_grab_fr [--config-file FILE] [--output FILE] [--days N] [--offset N] [--quiet] [--slow]
					m_strConfigFile = "tv_grab_fr.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_huro":
					m_strConfigFile = "tv_grab_huro.conf";
					m_intDays = 8;
					m_intOffset = 0;
					break;
				case "tv_grab_it":
					m_strConfigFile = "tv_grab_it.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
        case "tv_grab_na_dd":
          m_strConfigFile = "tv_grab_na_dd.conf";
          m_intDays = 7;
          m_intOffset = 0;
          break;
        case "tv_grab_nl":
					//    tv_grab_nl [--config-file FILE] --configure
					//    tv_grab_nl [--config-file FILE] [--output FILE] [--days N] [--offset N] [--quiet] [--slow]
					m_strConfigFile = "tv_grab_nl.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_nl_wolf":

					break;
				case "tv_grab_no":
					m_strConfigFile = "tv_grab_no.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_pt":
					m_strConfigFile = "tv_grab_pt.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_se":
					m_strConfigFile = "tv_grab_se.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_uk_rt":
					//    tv_grab_uk_rt [--config-file FILE] --configure
					//    tv_grab_uk_rt [--config-file FILE] [--output FILE] [--days N] [--offset N] [--slow] [--limit-details HH:MM-HH:MM]
					//                  [--get-categories] [--quiet]
					m_strConfigFile = "tv_grab_uk_rt.conf";
					m_intDays = 7;
					m_intOffset = 0;
					break;
				case "tv_grab_uk_bleb":

					break;
			}
		}
		private void GetSettings()
		{
			string grabberOutput=null;
			using(AMS.Profile.Xml   xmlreader=new AMS.Profile.Xml("MediaPortal.xml"))
			{
				grabberOutput=xmlreader.GetValueAsString("xmltv", "folder","xmltv");
				m_intGuidedays=xmlreader.GetValueAsInt("xmltv", "daystokeep",7);
				m_strOptions=xmlreader.GetValueAsString("xmltv", "args","--quiet");
			}
			m_strOutput= @System.IO.Path.GetFullPath(grabberOutput);

		}
	}
}