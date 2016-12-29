using Acr.UserDialogs;
using CrossApp.PCL.ServiceModels;
using CrossApp.PCL.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ViewModels
{
    public class CreateProjectViewModel : BaseViewModel
    {
        IUserDialogs _userDialog;
        IProjectService _projectService;
        IMvxPictureChooserTask _pictureChooserTask;

        public CreateProjectViewModel(IUserDialogs userDialog,
                    IProjectService projectService,
                    IMvxPictureChooserTask pictureChooserTask)
        {
            _projectService = projectService;
            _userDialog = userDialog;
            _pictureChooserTask = pictureChooserTask;
        }

        //Instance variables
        private string projectTitle = "";
        public string ProjectTitle
        {
            get { return projectTitle; }
            set { if (projectTitle == value) return; projectTitle = value; RaisePropertyChanged(() => ProjectTitle); }
        }


        private string projectDescription = "";
        public string ProjectDescription
        {
            get { return projectDescription; }
            set { if (projectDescription == value) return; projectDescription = value; RaisePropertyChanged(() => ProjectDescription); }
        }


        private DateTime createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; RaisePropertyChanged(() => CreatedDate); }
        }

        private DateTime expireDate = DateTime.Now;
        public DateTime ExpireDate
        {
            get { return expireDate; }
            set { expireDate = value; RaisePropertyChanged(() => ExpireDate); }
        }

        private ObservableCollection<Image> images = new ObservableCollection<Image>();
        public ObservableCollection<Image> Images
        {
            get { return images; }
            set { if (images == value) return; images = value; RaisePropertyChanged(() => Images); }
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

        //Job types
        HashSet<JobTypes> _jobTypes = new HashSet<JobTypes>();

        private bool _carpenter = false;
        public bool Carpenter
        {
            get { return _carpenter; }
            set {
                    if (_carpenter == false) _jobTypes.Add(JobTypes.Tømrer);
                    if (_carpenter == true) _jobTypes.Remove(JobTypes.Tømrer);
                    _carpenter = value;
                    RaisePropertyChanged(() => Carpenter);
                }
        }

        private bool _mason = false;
        public bool Mason
        {
            get { return _mason; }
            set
            {
                if (_mason == false) _jobTypes.Add(JobTypes.Murer);
                if (_mason == true) _jobTypes.Remove(JobTypes.Murer);
                _mason = value;
                RaisePropertyChanged(() => Mason);
            }
        }

        private bool _plumber = false;
        public bool Plumber
        {
            get { return _plumber; }
            set
            {
                if (_plumber == false) _jobTypes.Add(JobTypes.VVS);
                if (_plumber == true) _jobTypes.Remove(JobTypes.VVS);
                _plumber = value;
                RaisePropertyChanged(() => Plumber);
            }
        }

        private bool _electrician = false;
        public bool Electrician
        {
            get { return _electrician; }
            set
            {
                if (_electrician == false) _jobTypes.Add(JobTypes.Elektriker);
                if (_electrician == true) _jobTypes.Remove(JobTypes.Elektriker);
                _electrician = value;
                RaisePropertyChanged(() => Electrician);
            }
        }

        private bool _transport = false;
        public bool Transport
        {
            get { return _transport; }
            set
            {
                if (_transport == false) _jobTypes.Add(JobTypes.Transport);
                if (_transport == true) _jobTypes.Remove(JobTypes.Transport);
                _transport = value;
                RaisePropertyChanged(() => Transport);
            }
        }

        private bool _miscellaneous = false;
        public bool Miscellaneous
        {
            get { return _miscellaneous; }
            set
            {
                if (_miscellaneous == false) _jobTypes.Add(JobTypes.Andet);
                if (_miscellaneous == true) _jobTypes.Remove(JobTypes.Andet);
                _miscellaneous = value;
                RaisePropertyChanged(() => Miscellaneous);
            }
        }



        //End of instances variables
        //Methods

        private MvxCommand createdDateDialog;
        public MvxCommand CreatedDateDialog
        {
            get
            {
                createdDateDialog = createdDateDialog ?? new MvxCommand(DoCreatedDateDialog);
                return createdDateDialog;
            }
        }

        private async void DoCreatedDateDialog()
        {
            DatePromptConfig cnf = new DatePromptConfig();
            cnf.SelectedDate = CreatedDate;
            cnf.MinimumDate = DateTime.Now;
            cnf.CancelText = "Fortryd";
            cnf.IsCancellable = true;
            cnf.OkText = "Ok";

            var result = await _userDialog.DatePromptAsync(cnf);
            if (result.Ok)
                CreatedDate = result.SelectedDate;
        }

        private MvxCommand expireDateDialog;
        public MvxCommand ExpireDateDialog
        {
            get
            {
                expireDateDialog = expireDateDialog ?? new MvxCommand(DoExpireDateDialog);
                return expireDateDialog;
            }
        }

        private async void DoExpireDateDialog()
        {
            DatePromptConfig cnf = new DatePromptConfig();
            cnf.SelectedDate = ExpireDate;
            cnf.MinimumDate = DateTime.Now.AddDays(1);
            cnf.CancelText = "Fortryd";
            cnf.IsCancellable = true;
            cnf.OkText = "Ok";

            var result = await _userDialog.DatePromptAsync(cnf);
            if (result.Ok)
                ExpireDate = result.SelectedDate;
        }


        //Picture taking -----

        private MvxCommand choosePictureSourceCommand;

        public MvxCommand ChoosePictureSourceCommand
        {
            get
            {
                choosePictureSourceCommand = choosePictureSourceCommand ?? new MvxCommand(DoChoosePictureSourceCommand);
                return choosePictureSourceCommand;
            }
        }

        private async void DoChoosePictureSourceCommand()
        {
            ActionSheetConfig con = new ActionSheetConfig();

            ActionSheetOption library = new ActionSheetOption("Fra bibliotek", DoChoosePicture, await BitmapLoader.Current.LoadFromResource("album", null, null));
            ActionSheetOption camera = new ActionSheetOption("Fra kamera", DoTakePicture, await BitmapLoader.Current.LoadFromResource("camera", null, null));
            ActionSheetOption cancel = new ActionSheetOption("Fortryd", null, await BitmapLoader.Current.LoadFromResource("cancel", null, null));

            con.UseBottomSheet = true;
            con.Title = "Vælg et billede..";
            con.Options = new List<ActionSheetOption> { library, camera, cancel };
            _userDialog.ActionSheet(con);
        }


        private void DoTakePicture()
        {
            _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);

            Image image = new Image
            {
                ImageBytes = memoryStream.ToArray(),
                ImageName = "Billede " + (Images.Count + 1),
                Id = Guid.NewGuid()
            };
            Images.Add(image);
        }

        //End of picture taking ----

        private MvxAsyncCommand createProject;
        public MvxAsyncCommand CreateProject
        {
            get
            {
                createProject = createProject ?? new MvxAsyncCommand(CreateProjectMethod);
                return createProject;
            }
        }

        private async Task CreateProjectMethod()
        {
            //using loading indicator, gets auto disposed after use
            using (_userDialog.Loading("Opretter..", null, null, true, null))
            {
                Project project = new Project
                {
                    CreatedDate = createdDate,
                    ExpireDate = expireDate,
                    ProjectTitel = projectTitle,
                    ProjectDescription = projectDescription,
                    Images = images.ToList(),
                    Province = province,
                    JobType = _jobTypes.ToList()
                };
                try
                {
                    if (await _projectService.AddProject(project) != null)
                    {
                        CleanFields();
                        AlertDialog("Dit job er oprettet!", "Oprettelse udført", "Super");
                        return;
                    }
                    AlertDialog("Der er sket en fejl!", "Fejl", "Ok");
                }
                catch (Exception)
                {
                    AlertDialog("Der er sket en fejl!", "Fejl", "Ok");
                }
            }
                
        }

        private void CleanFields()
        {
            ProjectTitle = "";
            ProjectDescription = "";
            CreatedDate = DateTime.Today;
            ExpireDate = DateTime.Today;
            Images = new ObservableCollection<Image>();
            Province = Provinces.KøbenhavnsBy;
            Mason = Carpenter = Plumber = Electrician = Transport = Miscellaneous = false;
            _jobTypes = new HashSet<JobTypes>();
        }

        //Might gonna be moved to another class
        private async void AlertDialog(string msg, string title, string okText)
        {            
            await _userDialog.AlertAsync(msg, title, okText, null);
        }

    }
}
