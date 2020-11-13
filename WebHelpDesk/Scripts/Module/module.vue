<template>
    <div id="module">
        <h1>Module-Component3</h1>
        <div class="row">
            <button class="btn btn-primary" v-on:click="OpenModalModule">+</button>
        </div>
        <table class="table">
            <thead><tr><th>Name</th></tr></thead>
            <tbody>
                <tr v-for="obj in modules"><td>{{obj.moduleId}}</td><td scope="col">{{ obj.name }}</td></tr>
            </tbody>
        </table>
        <div class="modal fade" id="modalModule" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Module</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <label for="txtName">Name</label>
                        <input type="text" class="form-control" v-model="txtName" id="txtName" name="txtName" />
                        

                    </div>
                    <div class="modal-footer">
                        <button id="btnSave" name="btnSave" class="btn btn-primary" v-on:click="Save">Save</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import axios from 'axios';
    import * as $ from "jquery";
    import * as bootstrap from "bootstrap";
    export default {
        el: '#module',
        name: "module-component",
        data() {
            return {
                modules: [],
                txtName:''
            }
        },
        methods: {
            List: function (event) {
                axios.get('/Module/ListModules', {
                        dataType: 'json',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                          mode: 'no-cors',
                          credentials: 'include'
                }).then(response => {
                    console.log(response.data);
                    this.modules = response.data;
                });
            },
            OpenModalModule() {
                $('#modalModule').modal('show');
            },
            Save() {
                axios.post("/Module/SaveModule", null, { params: { Name: this.txtName }})
                .then(response => {
                    $('#modalModule').modal('hide');
                    this.List();
                });
            }
        }, mounted() {
            this.List();
        }
    }
</script>