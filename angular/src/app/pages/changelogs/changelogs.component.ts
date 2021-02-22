import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeLogService } from '@proxy/services/change-log.service';
import { PackageService } from '@proxy/services/package.service';
// import { PackageService } from '../../@core/service/package.service';

@Component({
  selector: 'app-changelogs',
  templateUrl: './changelogs.component.html',
})
export class ChangelogsComponent implements OnInit {

  public listVersion: any = [];
  public packageCurrent: any ;
  public listPackage: any;
  _form: FormGroup;
  isEdit: boolean = false;

  @ViewChild('model') model: ElementRef;

  constructor(
    private packageService: PackageService,
    private changelogService : ChangeLogService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    ) { }

  ngOnInit(): void {
    this.packageService.getAll().subscribe((res: any) => {
      console.log(res);
      this.listPackage = res;

      if(this.listPackage[0]) {
        this.packageCurrent = this.listPackage[0];
        this.getVersion(this.packageCurrent.id);
      }
    })
    this.buildForm();
  }

  showModel() {
    this.modalService.open(this.model, { ariaLabelledBy: "modal-basic-title", size: 'xs' });
  }

  buildForm() {
    this._form = this.fb.group({
      packageId: [null],
      url: [null],
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
      this.changelogService.update(this._form.value).subscribe((res) => {
        console.log(res);
      })
    } else {
      this.changelogService.insert(this._form.value).subscribe((res) => {
        console.log(res);
      })
    }
  }

  selectPackage(id: any) {
    this.packageCurrent = this.listPackage.find(x => x.id == id);
    this.getVersion(id);
  }

  addVersion() {
    this.showModel();
  }

  deleteVersion(id: any) {
    this.changelogService.delete(id).subscribe((res: any) => {
    })
  }

  editVersion(id: any) {
    let versionSelect = this.listVersion.find(x => x.Id == id);

    this._form.get("url").setValue(versionSelect.url);
    this._form.get("version").setValue(versionSelect.version);
    this._form.get("title").setValue(versionSelect.title);
    this._form.get("content").setValue(versionSelect.content);
    this._form.get("note").setValue(versionSelect.note);

    this.isEdit = true;
    this.showModel();
  }

  getVersion(id: any) {
    this.changelogService.getByPackageId(id).subscribe((res: any) => {
      this.listVersion = res;
    })
  }

}
