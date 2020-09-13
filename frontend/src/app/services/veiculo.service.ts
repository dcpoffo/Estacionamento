import { Veiculo } from './../models/Veiculo';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { MensagemService } from './mensagem.service';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  baseURL = `${environment.mainUrlAPI}veiculo`;

  constructor(
    private http: HttpClient,
    private mensagemServico: MensagemService
  ) { }

  getAll(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.baseURL).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  getById(id: number): Observable<Veiculo> {
    const url = `${this.baseURL}/${+id}`;
    console.log(url);
    return this.http.get<Veiculo>(url).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  put(veiculo: Veiculo): Observable<Veiculo> {
    const url = `${this.baseURL}/${veiculo.id}`;
    return this.http.put<Veiculo>(url, veiculo).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  post(veiculo: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(this.baseURL, veiculo).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  delete(id: number): Observable<Veiculo> {
    const url = `${this.baseURL}/${id}`;
    console.log(url);
    return this.http.delete<Veiculo>(url).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    console.log(e);
    this.mensagemServico.showMessage('Ocorreu um erro com o módulo Veículo!', true);
    return EMPTY;
  }
}
