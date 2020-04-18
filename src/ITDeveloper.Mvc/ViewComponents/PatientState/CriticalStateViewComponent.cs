using System.Threading.Tasks;
using ITDeveloper.Mvc.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ITDeveloper.Mvc.ViewComponents.PatitentState {
    [ViewComponent(Name = "CriticalState")]
    public class CriticalStateViewComponent : ViewComponent {
        public CriticalStateViewComponent() {

        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var total = Util.ToReg();
            var totalState = Util.GetRegByState();
            var progress = (totalState * 100) / total;
            var percent = progress.ToString(format: "F1");
            var model = new PatientStateData {
                Title = "Paciente Crítico",
                Partial = (int)totalState,
                Percent = percent,
                Progress = progress,
                ClassContainer = "panel panel-danger tile panelClose panelRefresh",
                IconLg = "progress-bar progress-bar-white",
                IconSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left"
            };
            return View(model);
        }
    }
}