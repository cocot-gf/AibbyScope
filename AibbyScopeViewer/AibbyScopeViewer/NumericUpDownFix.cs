using System.Windows.Forms;

namespace AibbyScopeViewer {
  // マウスホイールのスクロール量を無視してIncrementプロパティで増減するNumericUpDown
  // https://stackoverflow.com/questions/5226688/numericupdown-mousewheel-event-increases-decimal-more-than-one-increment

  public class NumericUpDownFix : NumericUpDown {
    protected override void OnMouseWheel(MouseEventArgs e) {
      HandledMouseEventArgs hme = e as HandledMouseEventArgs;
      if (hme != null) {
        hme.Handled = true;
      }

      if (e.Delta > 0 && (this.Value + this.Increment) <= this.Maximum) {
        this.Value += this.Increment;
      }
      else if (e.Delta < 0 && (this.Value - this.Increment) >= this.Minimum) {
        this.Value -= this.Increment;
      }
    }
  }
}
