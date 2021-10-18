import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EmpService {

  constructor(private httpClient:HttpClient) { }

  saveEmployee(EmployeeData:any){
    return this.httpClient.post("https://localhost:44310/Emp",EmployeeData);
  }

  updateEmployee(EmployeeData:any){
    return this.httpClient.put("https://localhost:44310/Emp",EmployeeData);
  }

  getAllEmployee(){
    return this.httpClient.get("https://localhost:44310/Emp");
  }

  getEmployeeByID(empid:any){
    return this.httpClient.get("https://localhost:44310/Emp/"+empid);
  }

  deleteEmployeeByID(empid:any){
    return this.httpClient.delete("https://localhost:44310/Emp/"+empid);
  }

}
