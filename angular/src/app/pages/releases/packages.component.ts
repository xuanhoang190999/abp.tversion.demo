import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PackageService } from '@proxy/services/package.service';

@Component({
  selector: 'app-packages',
  templateUrl: './packages.component.html',
  styleUrls: ['./releases.component.scss']
})
export class PackagesComponent implements OnInit {
  listPackage: any;
  _form: FormGroup;
  isEdit: boolean = false;
  idEdit: any;

  @ViewChild('model') model: ElementRef;

  constructor(
    private packageService: PackageService,
    private fb: FormBuilder,
    private modalService: NgbModal,
    ) { }

  ngOnInit(): void {
    this.packageService.get().subscribe((res: any) => {
      this.listPackage = res.items;
    })
  }

  buildForm() {
    this._form = this.fb.group({
      id: [0],
      name: [''],
      code: [''],
      image: ['']
    });
  }

  showModel() {
    this.modalService.open(this.model, { ariaLabelledBy: "modal-basic-title", size: 'xs' });
  }

  save() {
    if (this._form.invalid) {
      return;
    }

    if(this.isEdit) {
      this.packageService.update(this._form.value, this.idEdit).subscribe((res) => {
        console.log(res);
        this.isEdit = false;
        this.idEdit = null;
        this.ngOnInit();
      })
    } else {
      this.packageService.insert(this._form.value).subscribe((res) => {
        console.log(res);
        this.ngOnInit();
      })
    }
  }

  addPackage() {
    this.buildForm();
    this.isEdit = false;
    this.showModel();
  }

  deletePackage(id: any) {
    this.packageService.delete(id).subscribe((res: any) => {
      this.ngOnInit();
    })
  }

  editPackage(id: any) {
    this.idEdit = id;
    this.buildForm();
    let packageSelect = this.listPackage.find(x => x.id == id);

    this._form.get("id").setValue(packageSelect.id);
    this._form.get("name").setValue(packageSelect.name);
    this._form.get("code").setValue(packageSelect.code);
    this._form.get("image").setValue(packageSelect.image);

    this.isEdit = true;
    this.showModel();
  }

}
