from fastapi import FastAPI
from pydantic import BaseModel
from ai_service import generate_summary

app = FastAPI()

class NoteRequest(BaseModel):
    note_text:str

@app.post("/summarize")
def summarize(request: NoteRequest):
    return {
        "summary": generate_summary(request.note_text)}