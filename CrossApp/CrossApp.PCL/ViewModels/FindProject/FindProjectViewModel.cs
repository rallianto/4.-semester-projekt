using Acr.UserDialogs;
using CrossApp.PCL.ServiceModels;
using CrossApp.PCL.Services;
using CrossApp.PCL.ViewModels;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ViewModels
{
    public class FindProjectViewModel : BaseViewModel
    {
        IUserDialogs _userDialog;
        IProjectService _projectService;

        public FindProjectViewModel(IUserDialogs userDialog, IProjectService projectService)
        {
            _projectService = projectService;
            _userDialog = userDialog;
        }

        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set { if (_projects == value) return; _projects = value; RaisePropertyChanged(() => Projects); }
        }

        //Enum for spinner

        private Provinces province;
        public Provinces Province
        {
            get { return province; }
            set { if (province == value) return; province = value; RaisePropertyChanged(() => Province); }
        }

        private List<Provinces> provincesList = Enum.GetValues(typeof(Provinces)).Cast<Provinces>().ToList();
        public List<Provinces> ProvincesList
        {
            get { return provincesList; }
            set { if (provincesList == value) return; provincesList = value; RaisePropertyChanged(() => ProvincesList); }
        }

        private MvxAsyncCommand _searchCommand;
        public MvxAsyncCommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new MvxAsyncCommand(DoSearchCommand);
                return _searchCommand;
            }
        }

        private async Task DoSearchCommand()
        {
            //using loading indicator, gets auto disposed after use
            using (_userDialog.Loading("Søger..", null, null, true, null))
            {
                try
                {
                    var result = await _projectService.GetAllProjects();
                    if (result != null)
                    {
                        Projects = new ObservableCollection<Project>(result);
                        return;
                    }
                }
                catch (Exception)
                {
                    await _userDialog.AlertAsync("Har du adgang til internettet?", "Der skete en fejl", "Jeg tjekker lige..", null);
                }
            }           
        }

        private MvxCommand<Project> _itemSelectedCommand;
        public MvxCommand<Project> ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<Project>(DoItemSelectedCommand);
                return _itemSelectedCommand;
            }
        }
        private void DoItemSelectedCommand(Project project)
        {
            var bundle = new MvxBundle();
            bundle.Data.Add("Id", project.Id.ToString());
            ShowViewModel<ProjectDetailsViewModel>(bundle);
        }

    }
}
