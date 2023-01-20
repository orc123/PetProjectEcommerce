import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";

@Injectable({
    providedIn: 'root'
})
export class NotificationService{
    constructor(private _messageService: MessageService) {
    }

    showSuccess(message: string) {
        this.
            _messageService.add({ severity: 'success', summary: 'Thành công', detail: message });
    }

    showError(message: string) {
        this._messageService.add({ severity: 'error', summary: 'Lỗi', detail: message });
    }
}