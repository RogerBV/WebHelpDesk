<template>
    <div id="request">
        <button class="btn btn-warning" v-on:click="OpenModalRequest">+</button>
        <select class="form-control col-md-2" v-model="cboStates" id="cboStates" name="cboStates" @change="ListRequests">
            <option value="0">All</option>
            <option v-for="state in requestStates" v-bind:value="state.requestStateId">{{state.name}}</option>
        </select>

        <table class="table table-bordered" style="border-collapse:collapse;">
            <thead>
                <tr class="menu-bar d-flex">
                    <th class="col-3">Name</th>
                    <th class="col-1">State</th>
                    <th class="col-2">Attention User</th>
                    <th class="col-1">C. Date</th>
                    <th class="col-1">Goal Date</th>
                    <th class="col-1"></th>
                    <th class="col-1"></th>
                    <th class="col-1"></th>
                </tr>
            </thead>
            <tbody class="table-selected">
                <tr class="d-flex accordion-toggle" v-for="objRequest in requests">
                    <!--<td><button class="btn btn-default btn-xs"><span class="glyphicon glyphicon-eye-open"></span></button></td>-->
                    <td class="col-3">{{ objRequest.name }}</td>
                    <td class="col-1">{{ objRequest.stateName }}</td>
                    <td class="col-2">{{ objRequest.attentionUserName }}</td>
                    <td class="col-1">{{ objRequest.createDate }}</td>
                    <td class="col-1">{{ objRequest.goalDate }}</td>
                    <td v-on:click="ListEventsByRequest ( objRequest )" data-toggle="collapse" data-target="#demo1" class="center-cell col-1"><i class="material-icons">history</i></td>
                    <td v-on:click="OpenModalCloseRequest ( objRequest )" class="center-cell col-1"><i class="material-icons">done</i></td>
                    <td v-on:click="OpenModalRejectRequest ( objRequest )" class="center-cell col-1"><i class="material-icons">highlight_off</i></td>

                </tr>
                <tr>
                    <td colspan="12" class="hiddenRow">
                        <div class="accordian-body collapse" id="demo1">
                            <table class="table table-striped">
                                <thead>
                                    <tr><th>Type</th><th>Description</th><th>User</th><th>Date</th></tr>
                                </thead>
                                <tbody>
                                    <tr v-for="event in events">
                                        <td>{{event.eventTypeName}}</td>
                                        <td>{{event.description}}</td>
                                        <td>{{event.userName}}</td>
                                        <td>{{event.createDate}}</td>

                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </td>
                </tr>
            </tbody>
        </table>

        <div class="modal fade" id="modalRequest" role="dialog">
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
                        <label for="txtDescription">Description</label>
                        <textarea id="txtDescription" name="txtDescription" v-model="txtDescription" class="form-control" rows="3"></textarea>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="inputGroupFileAddon01">Upload</span>
                            </div>
                            <div class="custom-file">
                                <input type="file" class="custom-file-input" id="inputGroupFile01"
                                       aria-describedby="inputGroupFileAddon01" @change="fileChange($event.target.files)">
                                <label class="custom-file-label" for="inputGroupFile01">Choose file</label>
                            </div>
                        </div>
                        <label for="cboModule">Module</label>
                        <select id="cboModule" v-model="cboModule" name="cboModule" class="form-control">
                            <option value="0">Selection ...</option>
                            <option v-for="module in modules" selected="{{cboModule == requestId}}" v-bind:value="module.moduleId">{{module.name}}</option>
                        </select>
                    </div>
                    <div class="modal-footer">
                        <button id="btnSave" name="btnSave" class="btn btn-warning" v-on:click="Save">Save</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="modalEvents" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">History</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <table class="table table-bordered">
                            <thead class="menu-bar">
                                <tr class="d-flex">
                                    <th class="col-3">Type</th>
                                    <th class="col-5">Description</th>
                                    <th class="col-2">Date</th>
                                    <th class="col-3">User</th>
                                </tr>
                            </thead>
                            <tbody class="table-selected">
                                <tr class="d-flex" v-for="event in events">
                                    <td class="col-3">{{event.eventTypeName}}</td>
                                    <td class="col-5">{{event.description}}</td>
                                    <td class="col-2">{{event.createDate}}</td>
                                    <td class="col-3">{{event.userName}}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">

                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalCloseRequest" role="dialog">
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
                        <label>Are you sure about Close this request?</label>
                        <input type="text" class="form-control" v-model="txtRequestNameClose" id="txtRequestNameClose" name="txtRequestNameClose" disabled />

                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-warning" v-on:click="CloseRequest">Close Request</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalRejectRequest" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Reject</h5>
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
                        <label>Are you sure about Reject this request?</label>
                        <input type="text" class="form-control" v-model="txtRequestNameReject" id="txtRequestNameReject" name="txtRequestNameReject" disabled />
                        <textarea class="form-control" v-model="txtRejectDescription" id="txtRejectDescription" name="txtRejectDescription"></textarea>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-warning" v-on:click="RejectRequest">Close Request</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalRequestValidate" role="dialog">
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
    </div>
</template>
<script>
    import axios from 'axios';
    import * as $ from "jquery";

    export default {
        el: '#request',
        name: "request-component",
        data() {
            return {
                RequestId:0,
                requests:[],
                modules: [],
                events:[],
                requestStates:[],
                txtName: '',
                txtDescription:'',
                cboModule: 0,
                errors: [],
                FILE: null,
                files: new FormData(),
                cboStates: 0,
                txtRequestNameClose: '',
                txtRequestNameReject: '',
                txtRejectDescription:'',
                message:''
            }
        },
        methods: {
            CloseRequest: function (event) {
                axios.post("/Request/CloseRequest", null, { params: { RequestId: this.RequestId, UserId: this.cboUser } })
                    .then(response => {
                        $('#modalCloseRequest').modal('hide');
                        this.ListRequests();
                    });
            },
            RejectRequest: function (event) {
                axios.post("/Request/CreateRejectionByUser", null, { params: { RequestId: this.RequestId, UserId: this.cboUser,Description:this.txtRejectDescription } })
                    .then(response => {
                        $('#modalRejectRequest').modal('hide');
                        this.txtRejectDescription = "";
                        this.ListRequests();
                    });
            },
            OpenModalCloseRequest: function (event) {
                if (event.state == 3) {
                    this.RequestId = event.requestId;
                    this.txtRequestNameClose = event.name;
                    $("#modalCloseRequest").modal('show');
                } else {
                    this.message = 'Only close a request that was reviewed.'
                    $("#modalRequestValidate").modal('show');
                }
                
            },
            OpenModalRejectRequest: function (event) {
                if (event.state == 3) {
                    this.RequestId = event.requestId;
                    this.txtRequestNameReject = event.name;
                    $("#modalRejectRequest").modal('show');
                } else {
                    this.message = 'Only Reject a request that was reviewed.'
                    $("#modalRequestValidate").modal('show');
                }
                
            },
            ListEventsByRequest: function (event) {
                axios.get('/Request/ListEventsByRequest?RequestId='+event.requestId, {
                        dataType: 'json',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                          mode: 'no-cors',
                          credentials: 'include'
                }).then(response => {
                    this.events = response.data;
                    //$("#modalEvents").modal('show');
                });
            },
            fileChange(fileList) {
                this.FILE = event.target.files[0]
                for (let i = 0; i < fileList.length; i++) {
                    this.files.append("file", fileList[i], fileList[i].name);
                }
            },
            ClearForm() {
                this.txtName = '';
                this.txtDescription = '';
                this.cboModule = 0;
            },
            SaveRequest() {
                if (this.Validate()) {
                    this.Save();    
                }
            },
            Save() {
                const formData = new FormData()
                    formData.append('files', this.FILE);
                    formData.append('name', this.txtName);
                    formData.append('Description', this.txtDescription);
                    formData.append('ModuleId', this.cboModule);
                
                    axios.post('/Request/Save',
                        formData,
                        {
                            headers: {
                                'Content-Type': 'multipart/form-data'
                            }
                        }).then(response => {
                            $('#modalRequest').modal('hide');
                            this.ListRequests();
                        }).catch(error => {
                            alert(`something went wrong: ${error}`);
                        });
            },
            ListModules: function (event) {
                axios.get('/Request/ListModules', {
                        dataType: 'json',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                          mode: 'no-cors',
                          credentials: 'include'
                }).then(response => {
                    this.modules = response.data;
                });
            },
            ListRequests: function (event) {
                axios.get('/Request/ListRequestsByStateAndUser?State=' + this.cboStates, {
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

            ListRequestStates: function (event) {
                axios.get('/Request/ListRequestStates', {
                        dataType: 'json',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                          mode: 'no-cors',
                          credentials: 'include'
                }).then(response => {
                    this.requestStates = response.data;
                });
            },
            OpenModalRequest() {
                this.ClearForm();
                $('#modalRequest').modal('show');
            },
            Validate() {
                this.errors = [];
                if (this.txtName == '') {
                    this.errors.push('The field Name is empty.');
                    return false;
                }
                if (this.cboModule == 0) {
                    this.errors.push('The field Module is empty.');
                    return false;
                }
                return true;
            },
            
        }, mounted() {
            this.ListRequestStates();
            this.ListModules();
            this.ListRequests();
        }
    }
</script>