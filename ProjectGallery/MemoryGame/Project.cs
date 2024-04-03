using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common;

namespace MemoryGame;
public class Project : IProjectMeta {
	public string Name { get; set; } = "Memory Game";

	public BitmapImage Icon => new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/Plus.png", UriKind.Absolute));

	public void Run() {
		MainWindow window = new MainWindow();
		window.ShowDialog();
	}
}
