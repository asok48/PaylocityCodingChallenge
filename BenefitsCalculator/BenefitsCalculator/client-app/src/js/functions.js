import axios from 'axios';

function filterEmployees(firstName, lastName, id) {
    return axios.get('https://localhost:44360/Employee/filteremployees', {
        params: {
            firstName: firstName,
            lastName: lastName,
            id: id
        }
    })
}

function getDependents (employee) {
    return axios.get('https://localhost:44360/Dependent/getdependents', {
        params: {
            employeeId: employee.employeeId
        }
    })
}

function deleteEmployee(employee) {
    return axios.post('https://localhost:44360/Employee/deleteemployee', {
        firstName: employee.firstName,
        lastName: employee.lastName,
        employeeId: employee.employeeId
    })
}

function addDependent(firstName, lastName, employeeId) {
    return axios.post('https://localhost:44360/Dependent/adddependent', {
        firstName: firstName,
        lastName: lastName,
        employeeId: employeeId
    })
}

function deleteDependent(employeeId, id) {
    return axios.post('https://localhost:44360/Dependent/deletedependent', {
        employeeId: employeeId,
        id: id
    })
}

function addEmployee(firstName, lastName, employeeId) {
    return axios.post('https://localhost:44360/Employee/createemployee', {
        firstName: firstName,
        lastName: lastName,
        employeeId: employeeId
    })
}

function editDependent(firstName, lastName, id) {
    return axios.put('https://localhost:44360/Dependent/updatedependent', {
        firstName: firstName,
        lastName: lastName,
        id: id
    })
}

function getEmployee(employeeId) {
    return axios.get('https://localhost:44360/Employee/getemployee', {
        params: {
            employeeId: employeeId
        }
    })
}

function editEmployee(firstName, lastName, employeeId) {
    return axios.put('https://localhost:44360/Employee/updateemployee', {
            firstName: firstName,
            lastName: lastName,
            employeeId: employeeId
    })
}

export {
    filterEmployees,
    getEmployee,
    getDependents,
    deleteEmployee,
    addDependent,
    deleteDependent,
    addEmployee,
    editDependent,
    editEmployee
}