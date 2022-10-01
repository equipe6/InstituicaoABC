import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { StoreService } from '../store.service';
import { environment } from 'src/environments/environment';
@Injectable()
export class PessoaDataService {

  module: string = environment.apiUrl + '/api/pessoa';

  headers: HttpHeaders;

  constructor(
    private http: HttpClient,
    private store: StoreService,
  ) {
    this.headers = new HttpHeaders({
      'Content-Type':'application/json; charset=utf-8',
      'authorization': `bearer ${this.store.token}`
    })
  }

  getAll() {
    return this.http.get(this.module, { headers: this.headers });
  }

  getById(pessoa_id) {
    return this.http.get(`${this.module}/${pessoa_id}`, { headers: this.headers });
  }

  post(data) {
    return this.http.post(this.module, data, { headers: this.headers });
  }

  put(data) {
    return this.http.put(this.module, data, { headers: this.headers });
  }

  delete(pessoa_id) {
    return this.http.delete(`${this.module}/${pessoa_id}`, { headers: this.headers });
  }

  authenticate(data) {
    return this.http.post(this.module + '/authenticate', data, { headers: this.headers });
  }

}
