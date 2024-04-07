using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common;

namespace MemoryGame;
public class Project : IProjectMeta {
	public string Name { get; set; } = "Memory Game";

	public BitmapImage Icon {
		get {
			//return new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/Main.png", UriKind.Absolute));

			string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/Main.png");

			return new BitmapImage(uri);
		}
	}

	public void Run() {
		MainWindow window = new MainWindow();
		window.ShowDialog();
	}
}
