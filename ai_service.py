from openai import OpenAI
import os

client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))

SYSTEM_PROMPT = """
Simplify this diagnostic information for a patient, i.e. not someone in the medical profession.
-Summarize in 3-5 bullet points
-Do not diagnose
-Do not add new information
"""

def generate_summary(note_text: str) -> str:
    print("API key: ", os.getenv("OPENAI_API_KEY"))
    response = client.chat.completions.create(
        model="gpt-4o-mini",
        messages=[
            {"role": "system", "content": SYSTEM_PROMPT},
            {"role": "user", "content": note_text}
            ],
        max_tokens=150)

    return response.choices[0].message