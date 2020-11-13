<template>
    <div id="assignRequest">
        <select v-model="cboState" id="cboState" name="cboState" @change="ListRequests" class="form-control col-md-3">
            <option value="0">All</option>
            <option value="1">Pending</option>
            <option value="2">Assigned to User</option>
        </select>
        <table class="table table-bordered">
            <thead class="menu-bar">
                <tr class="d-flex">
                    <th class="col-3">Name</th>
                    <th class="col-1">Module</th>
                    <th class="col-2">User</th>
                    <th class="col-2">Attention User</th>
                    <th class="col-1">C. Date</th>
                    <th class="col-1">Goal Date</th>
                    <th class="col-1"></th>
                    <th class="col-1"></th>
                </tr>
            </thead>
            <tbody class="table-selected">
                <tr class="d-flex" v-for="objRequest in requests">
                    <td class="col-3">{{objRequest.name}}</td>
                    <td class="col-1">{{objRequest.moduleName}}</td>
                    <td class="col-2">{{objRequest.userName}}</td>
                    <td class="col-2">{{objRequest.attentionUserName}}</td>
                    <td class="col-1">{{objRequest.createDate}}</td>
                    <td class="col-1">{{objRequest.goalDate}}</td>
                    <td class="center-cell col-1" v-on:click="OpenModalAssignRequest ( objRequest )"><i class="material-icons">assignment_ind</i></td>
                    <td class="center-cell col-1" v-on:click="OpenModalRejectRequest ( objRequest )"><i class="material-icons">pan_tool</i></td>
                </tr>
            </tbody>
        </table>
        <div class="modal fade" id="modalAssign" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Request</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div v-if="errors.length" class="alert alert-danger" role="alert">
                            <ul>
                                <li v-for="error in errors">{{ error }}</li>
                            </ul>
                        </div>
                        <label for="txtName">Name</label>
                        <input type="text" class="form-control" v-model="txtName" id="txtName" name="txtName" />
                        <label for="cboUser">User</label>
                        <select class="form-control" v-model="cboUser" id="cboUser" name="cboUser">
                            <option value="0">Selection User...</option>
                            <option v-for="user in users" v-bind:value="user.userId" selected="{{ cboUser == UserId }}">{{user.name}}</option>
                        </select>
                        <label for="txtAttentionDate">Attention Date</label>
                        <input type="date" class="form-control" v-model="txtAttentionDate" id="txtAttentionDate" name="txtAttentionDate" />
                    </div>
                    <div class="modal-footer">
                        <button id="btnSave" name="btnSave" class="btn btn-warning" v-on:click="AssignRequest">Save</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalAssignValidate" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Alert</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        
                        <label>{{ message }}</label>
                        
                    </div>
                    <div class="modal-footer">
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalRejectRequest" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Request</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <input type="text" v-model="txtRequestName" class="form-control" disabled />
                        <label>Are you sure about reject this request?</label>
                        <textarea id="txtDescription" name="txtDescription" v-model="txtDescription" class="form-control" placeholder="Description"></textarea>
                    </div>
                    <div class="modal-footer">
                        <button id="btnSave" name="btnSave" class="btn btn-warning" v-on:click="CreateRejectionByAdministrator">Reject</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import axios from 'axios';
    import * as $ from "jquery";

    export default {
        el: '#assignRequest',
        name: 'assignRequest-component',
        data() {
            return {
                errors:[],
                requests: [],
                requestId:0,
                txtName: '',
                txtDescription: '',
                txtRequestName:'',
                users: [],
                cboState:0,
                cboUser: 0,
                UserId:0,
                txtAttentionDate: new Date(),
                message:''
            }
        },
        methods: {
            ListRequests: function (event) {
                axios.get('/Request/ListRequestsByState?State=' + this.cboState, {
                        dataType: 'json',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                          mode: 'no-cors',
                          credentials: 'include'
                }).then(response => {
                    this.requests = response.data;
                });
            },
            ListUsers: function (event) {
                axios.get('/Request/ListUsers', {
                    dataType: 'json',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type':'application/json'
                    },
                    mode: 'no-cors',
                    credentials:'include'
                }).then(response => {
                    this.users = response.data;
                })
            },
            OpenModalAssignRequest: function (event) {
                if (event.state == 1 || event.state == 2) {
                    $('#modalAssign').modal('show');
                    this.MappingEntityForm(event);
                }
                else {
                    if (event.state == 3) {
                        this.message = 'A request that was reviewed can not be assign to user.';
                    } else if (event.state == 4 || event.state == 6) {
                        this.message = 'A request that was rejected can not be assign to user.';
                    } else if (event.state == 5) {
                        this.message = 'A request that was closed can not be assign to user.';
                    }
                    
                    $('#modalAssignValidate').modal('show');
                }
                
                
            },
            OpenModalRejectRequest(event) {
                console.log("Ventana");
                this.RequestId = event.requestId;
                this.txtRequestName = event.name;
                if (event.state == 1 || event.state == 2) {
                    $('#modalRejectRequest').modal('show');
                } else {
                    this.message = 'You only reject a request with state Pending or Assigned.';
                    $('#modalAssignValidate').modal('show');
                }
                
            },
            MappingEntityForm(event) {
                this.RequestId = event.requestId;
                this.UserId = event.attentionUserId;
                this.cboUser = event.attentionUserId;
                this.txtName = event.name;
                if (event.state == 1) {
                    this.txtAttentionDate = new Date();
                } else {
                    this.txtAttentionDate = event.attentionDate;
                }
            },
            AssignRequest: function (event) {
                if (this.ValidateAssignRequest()) {
                    axios.post("/Request/AssignRequest", null, { params: { RequestId: this.RequestId, AttentionUserId:this.cboUser, GoalDate: this.txtAttentionDate,State : 2 } })
                    .then(response => {
                        $('#modalAssign').modal('hide');
                        this.ListRequests();
                    });
                }
                
            },
            ValidateAssignRequest() {
                this.errors = [];
                if (this.cboUser == 0) {
                    this.errors.push('You must select a user.');
                    return false;
                }
                return true;
            },
            CreateRejectionByAdministrator: function (event) {
                axios.post("/Request/CreateRejectionByAdministrator", null, { params: { RequestId: this.RequestId, Description: this.txtDescription } })
                    .then(response => {
                        $('#modalRejectRequest').modal('hide');
                    });
            },
            downloadItem ({ url, label }) {
                Axios.get(url, { responseType: 'blob' })
                .then(response => {
                    const blob = new Blob([response.data], { type: 'application/pdf' })
                    const link = document.createElement('a')
                    link.href = URL.createObjectURL(blob)
                    link.download = label
                    link.click()
                    URL.revokeObjectURL(link.href)
                }).catch(console.error)
            }

        },
        mounted() {
            this.ListRequests();
            this.ListUsers();   
        }
    }
</script>