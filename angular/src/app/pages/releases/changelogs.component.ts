import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IModelYesNo } from '@proxy/models/models';
import { ChangeLogService } from '@proxy/services/change-log.service';
import { PackageService } from '@proxy/services/package.service';
import { UserService } from '@proxy/services/user.service';
// import { PackageService } from '../../@core/service/package.service';

@Component({
  selector: 'app-changelogs',
  templateUrl: './changelogs.component.html',
  styleUrls: ['./releases.component.scss']
})
export class ChangelogsComponent implements OnInit {

  public listChangelog: any = [];
  public packageCurrent: any ;
  public listPackage: any;
  _form: FormGroup;
  permission: boolean = false;
  userLogged: any;
  dataModal: IModelYesNo;
  isActive: any;
  idActive: any;

  @ViewChild('model') model: ElementRef;
  @ViewChild('modelDelete') modelDelete: ElementRef;
  @Output() valueChange = new EventEmitter();

  constructor(
    private packageService: PackageService,
    private changelogService : ChangeLogService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private userService: UserService
    ) { }

  ngOnInit(): void {
    this.packageService.get().subscribe((res: any) => {
      this.listPackage = res.items;

      if(this.listPackage[0]) {
        this.packageCurrent = this.listPackage[0];
        this.getChangelog(this.packageCurrent.id);
      }
    })

    this.userService.getUserLogged().subscribe((res: any) => {
      console.log(res)
      this.userLogged = res;
      if(this.userLogged.role.length > 0) {
        this.getRole(this.userLogged.role);
      }
    })

  }

  buildForm() {
    this._form = this.fb.group({
      id: [null],
      packageId: [null],
      url: [''],
      version: [null, Validators.required],
      title: [null, Validators.required],
      content: [null, Validators.required],
      note: [null]
    });
  }

  save() {
    // if (this._form.invalid) {
    //   return;
    // }
    this._form.get("packageId").setValue(this.packageCurrent.id);

    if(this.isActive == 'update') {
      this.changelogService.update(this._form.value, this.idActive).subscribe((res) => {
        this.getChangelog(this.packageCurrent.id);
      })
    }
    else if(this.isActive == 'add') {
      this.changelogService.insert(this._form.value).subscribe((res) => {
        this.getChangelog(this.packageCurrent.id);
      })
    }
    else if(this.isActive == 'delete') {
      this.changelogService.delete(this.idActive).subscribe((res: any) => {
        this.getChangelog(this.packageCurrent.id);
      })
    }

    this.closeModel();
  }

  onActive(active: any, id: any) {
    this.isActive = active;
    this.idActive = id;
    this.buildForm();

    if(active == 'add') {
      this.modalService.open(this.model, { ariaLabelledBy: "modal-basic-title", size: 'xs' });
    }
    else if(active == 'update') {
      let ChangelogSelect = this.listChangelog.find(x => x.id == id);

      this._form.get("id").setValue(ChangelogSelect.id);
      this._form.get("url").setValue(ChangelogSelect.url ?? '');
      this._form.get("version").setValue(ChangelogSelect.version);
      this._form.get("title").setValue(ChangelogSelect.title);
      this._form.get("content").setValue(ChangelogSelect.content);
      this._form.get("note").setValue(ChangelogSelect.note);

      this.modalService.open(this.model, { ariaLabelledBy: "modal-basic-title", size: 'xs' });
    }
    else if(active == 'delete') {
      this.modalService.open(this.modelDelete, { ariaLabelledBy: "modal-basic-title", size: 'sm' });
    }
  }

  selectPackage(id: any) {
    this.packageCurrent = this.listPackage.find(x => x.id == id);
    this.getChangelog(id);
  }

  getChangelog(id: any) {
    this.changelogService.getByPackageId(id).subscribe((res: any) => {
      this.listChangelog = res;

      this.listChangelog.sort(function(a,b) {
        return new Date(a.creationTime).getTime() < new Date(b.creationTime).getTime() ? 1 : -1;
      });
    })
  }

  closeModel() {
    this.modalService.dismissAll();
  }

  getRole(roles: any) {
    var check = roles.findIndex(x => x == 'admin');
    if(check > -1) {
      this.permission = true;
    }
  }

}
