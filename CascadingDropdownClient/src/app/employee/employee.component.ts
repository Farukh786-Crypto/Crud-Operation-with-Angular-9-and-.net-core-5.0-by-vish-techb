import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http'
import { EmpService } from './emp.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employeeForm: any;
  employeeList: any;
  empid:Number=0;
  btnSave: string = "Save";
  constructor(private httpClient: HttpClient, private empservice: EmpService) {
    // use Link for Running Applications -: http://localhost:4200/create-employee
    this.employeeForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }
  ngOnInit(): void {
    this.GetEmployeeData();
  }

  public SubmitData(data: any) {
    // if data present then update
    if (this.empid && this.empid > 0) {
      // object contain id too
      const empdataforupdate = {
        id: this.empid, name: this.employeeForm.controls.name.value,
        email: this.employeeForm.controls.email.value,
        password: this.employeeForm.controls.password.value
      };
      this.empservice.updateEmployee(empdataforupdate).subscribe(data => {
        this.GetEmployeeData();
        this.employeeForm.reset();
        this.btnSave = "Save";
      })
    }
    else {
      var obervable = this.empservice.saveEmployee(this.employeeForm.value);
      obervable.subscribe(
        data => {
          console.log(data);
          this.GetEmployeeData();
          this.employeeForm.reset();
        });
    }
  }

  GetEmployeeData() {
    var obervable = this.empservice.getAllEmployee();
    obervable.subscribe(
      data => {
        this.employeeList = data; // this data show on table
      });
  }

  edit(id:any) {
    // store response in any bydefault store in object
    this.empservice.getEmployeeByID(id).subscribe((data:any) => {
      this.empid = data.id;
      this.btnSave = "Update";
      this.employeeForm.patchValue(data); // compare with control and attach to form
      console.log(data);
    });
  }
  delete(id: number) {
    this.empservice.deleteEmployeeByID(id).subscribe(data => {
      this.GetEmployeeData();
    })
  }

}
