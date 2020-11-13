<template>
    <div id="attention">
        <select v-model="cboState" id="cboState" name="cboState" @change="ListRequests" class="form-control col-md-3">
            <option value="0">All</option>
            <option value="2">Assigned</option>
            <option value="3">Reviewed</option>
            <option value="4">Rejected</option>
            <option value="5">Closed</option>
        </select>
        <table class="table table-bordered">
            <thead class="menu-bar">
                <tr class="d-flex">
                    <th class="col-3">Name</th>
                    <th class="col-1">Module</th>
                    <th class="col-2">User</th>
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
                    <td class="col-1">{{objRequest.createDate}}</td>
                    <td class="col-1">{{objRequest.goalDate}}</td>
                    <td v-on:click="ListEventsByRequest ( objRequest )" class="center-cell col-1"><i class="material-icons">schedule</i></td>
                    <td class="center-cell col-1" v-on:click="FindRequest(objRequest)">
                        <i class="material-icons">done_outline</i>
                    </td>
                    <td class="center-cell col-1" v-on:click="downloadItem(objRequest.sourceFile, objRequest.fileName)">
                        <i class="material-icons">cloud_download</i>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="modal fade" id="modalAttention" role="dialog">
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
                        <input type="text" class="form-control" v-model="txtName" id="txtName" name="txtName" disabled />
                        <label for="txtDescription">Description</label>
                        <textarea v-model="txtDescription" id="txtDescription" name="txtDescription" class="form-control" disabled></textarea>
                        <label for="txtGoalDate">Goal Date</label>
                        <input type="date" v-model="txtGoalDate" class="form-control" id="txtGoalDate" name="txtGoalDate" disabled />
                        <label for="txtAttentionDescription">Attention Description</label>
                        <textarea v-model="txtAttentionDescription" id="txtAttentionDescription" name="txtAttentionDescription" class="form-control"></textarea>

                    </div>
                    <div class="modal-footer">
                        <button id="btnSave" name="btnSave" class="btn btn-warning" v-on:click="CreateReview">Save</button>
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

                                </tr>
                            </thead>
                            <tbody class="table-selected">
                                <tr class="d-flex" v-for="event in events">
                                    <td class="col-3">{{event.eventTypeName}}</td>
                                    <td class="col-5">{{event.description}}</td>
                                    <td class="col-2">{{event.createDate}}</td>

                                </tr>
                                <tr>
                                    <td colspan="12" class="hiddenRow">
                                        <div class="accordian-body collapse" id="demo1">
                                            <table class="table table-striped">
                                                <thead>
                                                    <tr><th>Type</th><th>Description</th><th>C. Date </th><th>Actions</th></tr>
                                                </thead>
                                                <tbody>
                                                    <tr v-for="event in events">
                                                        <td>{{event.eventTypeName}}</td>
                                                        <td>{{event.description}}</td>
                                                        <td>{{event.createDate}}</td>
                                                        <td>
                                                            <a href="#" class="btn btn-default btn-sm">
                                                                <i class="glyphicon glyphicon-cog"></i>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">

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
    import axios from "axios";
    import * as $ from "jquery";
    export default {
        el: "#attention",
        name: "attention-component",
        data() {
            return {
                errors:[],
                requests: [],
                cboState: '0',
                RequestId:0,
                txtName: '',
                txtDescription: '',
                txtGoalDate: new Date(),
                events: [],
                message:''
            }
            
        },
        methods: {
            ListEventsByRequest: function (event) {
                console.log(event);
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
                    $("#modalEvents").modal('show');
                });
            },
            ListRequests: function (event) {
                axios.get('/Request/ListRequestsByAttentionUser?State='+this.cboState, {
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
            CreateReview() {
                axios.post("/Request/CreateReview", null, { params: { Description: this.txtAttentionDescription, RequestId: this.RequestId } })
                        .then(response => {
                        $('#modalAttention').modal('hide');
                        this.ListRequests();
                    });
            },
            OpenModal() {
                $("#modalAttention").modal("show");
            },
            FindRequest(request) {
                if (request.state == 2 || request.state == 4) {
                    this.RequestId = request.requestId;
                    this.txtName = request.name;
                    this.txtDescription = request.description;
                    this.txtGoalDate = request.goalDate;
                    this.OpenModal();
                } else {
                    this.message = 'The user just review  a request reviews or rejected.'
                    $("#modalRequestValidate").modal('show');
                }
            },
            downloadItem ( url,file  ) {
                axios.get(url,{responseType: 'arraybuffer'})
                .then(response => {
                    console.log(response);
                    var headers = response.headers;
                    var blob = new Blob([response.data],{type:headers['content-type']});
                    var link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    link.download = file;
                    link.click();
                }).catch(console.error)
            }
        },
        mounted() {
            this.ListRequests();
        }
    }
</script>