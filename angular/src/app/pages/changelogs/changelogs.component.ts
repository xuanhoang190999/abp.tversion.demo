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
  public versionCurrent: any ;
  public listPackage: any;
  _form: FormGroup;

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
        this.versionCurrent = this.listPackage[0];
        this.getVersion(this.versionCurrent.id);
      }
    })
  }

  showModel() {
    this.buildForm();
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

    this._form.get("packageId").setValue(this.versionCurrent.id);

    this.changelogService.insert(this._form.value).subscribe((res) => {
      console.log(res);
    })
  }

  selectPackage(id: any) {
    this.listVersion = this.getVersion(id);
  }

  deleteVersion(id: any) {

  }

  editVersion(id: any) {

  }

  getVersion(id: any) {
    this.changelogService.getByPackageId(id).subscribe((res: any) => {
      this.listVersion = res;
    })
  }

}
