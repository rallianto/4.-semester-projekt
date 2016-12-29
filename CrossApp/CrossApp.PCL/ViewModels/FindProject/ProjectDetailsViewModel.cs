using Acr.UserDialogs;
using CrossApp.PCL.ServiceModels;
using CrossApp.PCL.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossApp.PCL.ViewModels
{
    public class ProjectDetailsViewModel : MvxViewModel
    {
        private Guid _id;

        IUserDialogs _userDialog;
        IProjectService _projectService;

        public ProjectDetailsViewModel(IUserDialogs userDialog, IProjectService projectService)
        {
            _projectService = projectService;
            _userDialog = userDialog;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            string id;
            if (parameters.Data.TryGetValue("Id", out id))
            {
                _id = new Guid(id);
            }
            else
            {
                throw new ArgumentException("Missing id");
            }
        }

        public override async void Start()
        {
            base.Start();
            //using loading indicator, gets auto disposed after use
            using (_userDialog.Loading("Henter..", null, null, true, null))
            {
                try
                {
                    var result = await _projectService.FindProjectById(_id);
                    if (result != null)
                    {
                        CurrentProject = result;
                        System.Diagnostics.Debug.WriteLine("First image property: " + FirstImage.ImageName);
                    }
                }
                catch (Exception)
                {
                    await _userDialog.AlertAsync("Har du adgang til internettet?", "Der skete en fejl", "Jeg tjekker lige..", null);
                }
            }
            
        }

        private string _username;
        private int _priceOffer;

        private Project _currentProject;
        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                _currentProject = value;

                RaisePropertyChanged(() => CurrentProject);
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => Description);
                RaisePropertyChanged(() => Images);
                RaisePropertyChanged(() => CreatedDate);
                RaisePropertyChanged(() => ExpireDate);
                RaisePropertyChanged(() => Province);
                RaisePropertyChanged(() => JobType);
                RaisePropertyChanged(() => FirstImage);
            }
        }

        public string Title { get { return CurrentProject.ProjectTitel; } }

        public string Description { get { return CurrentProject.ProjectDescription; } }

        public List<Image> Images { get { return CurrentProject.Images; } }

        public DateTime CreatedDate { get { return CurrentProject.CreatedDate; } }

        public DateTime ExpireDate { get { return CurrentProject.ExpireDate; } }

        public Provinces Province { get { return CurrentProject.Province; } }

        public List<JobTypes> JobType { get { return CurrentProject.JobType; } }

        public Image FirstImage { get { return CurrentProject.Images.FirstOrDefault(); } }

        private MvxCommand _navBack;

        public MvxCommand NavBack
        {
            get
            {
                _navBack = _navBack ?? new MvxCommand(DoNavBack);
                return _navBack;
            }
        }

        private void DoNavBack()
        {
            ShowViewModel<FindProjectViewModel>();
        }

        private MvxCommand _makeOffer;

        public MvxCommand MakeOffer
        {
            get
            {
                _makeOffer = _makeOffer ?? new MvxCommand(DoMakeOffer);
                return _makeOffer;
            }
        }

        private void DoMakeOffer()
        {
            PromptConfig config = new PromptConfig();
            config.CancelText = "Cancel";
            config.IsCancellable = true;
            config.Message = "Angiv brugernavn";
            config.OkText = "Ok";
            config.Title = "Angiv bud";
            config.InputType = InputType.Name;
            config.OnAction = _onAction;

            _userDialog.Prompt(config);
        }

        private void _onAction(PromptResult res)
        {
            if (res.Ok)
            {
                _username = res.Text;
                _userDialog.Alert("Vi har gemt dit navn");
            }
            else if (!res.Ok)
            {
                _userDialog.Alert("Du trykkede fortryd");
            }

        }


    }
}
