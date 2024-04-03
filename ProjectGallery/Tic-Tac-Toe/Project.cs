using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common;

namespace Tic_Tac_Toe;
public class Project : IProjectMeta {
	public string Name { get; set; } = "Tic-Tac-Toe";

	public BitmapImage Icon => new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/Main.png", UriKind.Absolute));
}