import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeLogService } from '@proxy/services/change-log.service';
import { PackageService } from '@proxy/services/package.service';
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

  @ViewChild('model') model: ElementRef;

  constructor(
    private packageService: PackageService,
    private changelogService : ChangeLogService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    ) { }

  ngOnInit(): void {
    this.packageService.get().subscribe((res: any) => {
      console.log(res);
      this.listPackage = res.items;

      if(this.listPackage[0]) {
        this.packageCurrent = this.listPackage[0];
        this.getChangelog(this.packageCurrent.id);
      }
    })
    this.buildForm();
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

    console.log(this._form.value)

    if(this.isEdit) {
      this.changelogService.update(this._form.value, this.packageCurrent.id).subscribe((res) => {
        console.log(res);
        this.getChangelog(this.packageCurrent.id);
      })
    } else {
      this.changelogService.insert(this._form.value).subscribe((res) => {
        console.log(res);
        this.getChangelog(this.packageCurrent.id);
      })
    }
  }

  selectPackage(id: any) {
    this.packageCurrent = this.listPackage.find(x => x.id == id);
    this.getChangelog(id);
  }

  addChangelog() {
    this.isEdit = false;
    this.showModel();
  }

  deleteChangelog(id: any) {
    this.changelogService.delete(id).subscribe((res: any) => {
      this.getChangelog(this.packageCurrent.id);
    })
  }

  editChangelog(id: any) {
    let ChangelogSelect = this.listChangelog.find(x => x.id == id);

    console.log(ChangelogSelect)

    this._form.get("id").setValue(ChangelogSelect.id);
    this._form.get("url").setValue(ChangelogSelect.url ?? '');
    this._form.get("version").setValue(ChangelogSelect.version);
    this._form.get("title").setValue(ChangelogSelect.title);
    this._form.get("content").setValue(ChangelogSelect.content);
    this._form.get("note").setValue(ChangelogSelect.note);

    this.isEdit = true;
    this.showModel();
  }

  getChangelog(id: any) {
    this.changelogService.getByPackageId(id).subscribe((res: any) => {
      this.listChangelog = res;
    })
  }

}
