import { Employee } from './employee.model';

describe('EmployeeModel', () => {
  it('should create an instance', () => {
    expect(new Employee()).toBeTruthy();
  });
});
