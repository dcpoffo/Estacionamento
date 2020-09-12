import { Preco } from './../models/Preco';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { MensagemService } from './mensagem.service';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PrecoService {

  baseURL = `${environment.mainUrlAPI}preco`;

  constructor(
    private http: HttpClient,
    private mensagemServico: MensagemService
  ) { }

  getAll(): Observable<Preco[]> {
    return this.http.get<Preco[]>(this.baseURL).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  getById(id: number): Observable<Preco> {
    const url = `${this.baseURL}/${id}`;
    return this.http.get<Preco>(url).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  put(preco: Preco): Observable<Preco> {
    const url = `${this.baseURL}/${preco.id}`;
    return this.http.put<Preco>(url, preco).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  post(preco: Preco): Observable<Preco> {
    return this.http.post<Preco>(this.baseURL, preco).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  delete(id: number): Observable<Preco> {
    const url = `${this.baseURL}/${id}`;
    return this.http.delete<Preco>(url).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    console.log(e);
    this.mensagemServico.showMessage('Ocorreu um erro com o módulo Preço!', true);
    return EMPTY;
  }

}
