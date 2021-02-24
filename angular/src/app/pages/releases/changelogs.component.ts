import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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
  isEdit: boolean = false;
  idEdit: any;
  permission: boolean = false;
  userLogged: any;

  @ViewChild('model') model: ElementRef;

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

  showModel() {
    this.modalService.open(this.model, { ariaLabelledBy: "modal-basic-title", size: 'xs' });
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
    if (this._form.invalid) {
      return;
    }

    this._form.get("packageId").setValue(this.packageCurrent.id);

    if(this.isEdit) {
      this.changelogService.update(this._form.value, this.idEdit).subscribe((res) => {
        console.log(res);
        this.getChangelog(this.packageCurrent.id);
        this.idEdit= null;
        this.isEdit = false;
      })
    } else {
      this.changelogService.insert(this._form.value).subscribe((res) => {
        console.log(res);
        this.getChangelog(this.packageCurrent.id);
        this.isEdit = false;
      })
    }

    this.closeModel();
  }

  selectPackage(id: any) {
    this.packageCurrent = this.listPackage.find(x => x.id == id);
    this.getChangelog(id);
  }

  addChangelog() {
    this.buildForm();

    this.isEdit = false;
    this.showModel();
  }

  deleteChangelog(id: any) {
    this.changelogService.delete(id).subscribe((res: any) => {
      this.getChangelog(this.packageCurrent.id);
    })
  }

  editChangelog(id: any) {
    this.buildForm();

    let ChangelogSelect = this.listChangelog.find(x => x.id == id);

    console.log(ChangelogSelect)

    this._form.get("id").setValue(ChangelogSelect.id);
    this._form.get("url").setValue(ChangelogSelect.url ?? '');
    this._form.get("version").setValue(ChangelogSelect.version);
    this._form.get("title").setValue(ChangelogSelect.title);
    this._form.get("content").setValue(ChangelogSelect.content);
    this._form.get("note").setValue(ChangelogSelect.note);

    this.isEdit = true;
    this.idEdit = id;
    this.showModel();
  }

  getChangelog(id: any) {
    this.changelogService.getByPackageId(id).subscribe((res: any) => {
      this.listChangelog = res;
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
